using HelmetShop.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {

        [HttpGet]
        public IActionResult Get([FromServices] IApplicationUser user)
        {
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromServices] IApplicationUser user)
        {
            return Ok(user);
        }
    }
}
