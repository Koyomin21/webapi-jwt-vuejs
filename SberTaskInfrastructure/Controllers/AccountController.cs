using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SberTaskInfrastructure.Models;
using SberTaskInfrastructure.Services;

namespace SberTaskInfrastructure.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ResponseModel> Login([FromBody] UserLogin userLogin)
        {

            return await _userService.Login(userLogin);
        }
    }
}
