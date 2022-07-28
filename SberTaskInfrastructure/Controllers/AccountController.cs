using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SberTaskInfrastructure.Models;
using SberTaskInfrastructure.Services;
using System.IdentityModel.Tokens.Jwt;

namespace SberTaskInfrastructure.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseResult<TokenModel> responseResult = await _userService.Login(userLogin);

            if(!responseResult.Succeeded)
            {
                return BadRequest(responseResult);
            }

            return Ok(responseResult);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ResponseResult> Register([FromBody] UserRegistration userRegistration)
        {

            return await _userService.Register(userRegistration);
        }

    }
}
