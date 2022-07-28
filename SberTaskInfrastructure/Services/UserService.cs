using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SberTaskDLA.Extensions;
using SberTaskDLA.Models;
using SberTaskInfrastructure.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SberTaskInfrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<ResponseResult<TokenModel>> Login(UserLogin userLogin)
        {
            var user = await _userManager.FindByPhoneNumberAsync(userLogin.PhoneNumber);
            if(user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                };

                var token = GenerateToken(authClaims);

                var tokenModel = new TokenModel()
                {
                    Value = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiresInMinutes = _configuration["JWT:ExpiresInMinutes"]
                };

                return ResponseResult<TokenModel>.Ok(tokenModel);

            }

            return ResponseResult<TokenModel>.Fail("Wrong Credentials!");
            
        }

        public async Task<ResponseResult> Register(UserRegistration userRegistration)
        {
            var userExists = await _userManager.FindByPhoneNumberAsync(userRegistration.PhoneNumber);
            if(userExists != null)
            {
                return ResponseResult.Fail("Already exists");
            }

            ApplicationUser user = new()
            {
                PhoneNumber = userRegistration.PhoneNumber,
                UserName = userRegistration.PhoneNumber,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                MiddleName = userRegistration.MiddleName,
                Email = userRegistration.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if(result.Succeeded)
            {
                var userRole = await _roleManager.FindByNameAsync("User");
                await _userManager.AddToRoleAsync(user, userRole.Name);
            }

            return ResponseResult.Ok();


        }

        public JwtSecurityToken GenerateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration["JWT:ExpiresInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
