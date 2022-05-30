using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
       

        // POST api/<InitialDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
         
        }
     
    }
}
