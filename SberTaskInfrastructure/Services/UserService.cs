using Microsoft.AspNetCore.Identity;
using SberTaskDLA.Extensions;
using SberTaskDLA.Models;
using SberTaskInfrastructure.Models;

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
        public async Task<ResponseModel> Login(UserLogin userLogin)
        {
            var user = await _userManager.FindByPhoneNumberAsync(userLogin.PhoneNumber);
            

            return new ResponseModel()
            {
                Status = 200,
                Message = "Nice"
            };
        }

        public async Task<ResponseModel> Register(UserRegistration userRegistration)
        {
            var userExists = await _userManager.FindByPhoneNumberAsync(userRegistration.PhoneNumber);
            if(userExists != null)
            {
                return new ResponseModel() { Status = 500, Message = "The User already exists!" };
            }

            ApplicationUser user = new()
            {
                PhoneNumber = userRegistration.PhoneNumber,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                MiddleName = userRegistration.MiddleName,
                Email = userRegistration.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if(result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User");
            }

            return new ResponseModel() { Status = 200, Message = "Successfully Registered" };

        }
    }
}
