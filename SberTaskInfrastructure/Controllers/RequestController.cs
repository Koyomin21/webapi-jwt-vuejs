using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SberTaskInfrastructure.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [Route("/testMethod")]
        [HttpGet]
        public String TestGetMethod()
        {
            return "somethnig";
        }

        [Authorize]
        [Route("/authorizedMethod")]
        [HttpGet]
        public String AuthorizedMethod()
        {
            return "authorized";
        }

        [Authorize(Roles = "Admin")]
        [Route("/authorizedMethodAdmin")]
        [HttpGet]
        public String AuthorizedMethodAdmin()
        {
            return "authorized for Admins";
        }
    }
}
