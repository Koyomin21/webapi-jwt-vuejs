using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SberTaskInfrastructure.Controllers
{
    [Route("api/[controller]")]
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
    }
}
