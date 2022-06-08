using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /*
        private IGetCategoriesQuery _query;

        public CategoriesController(IGetCategoriesQuery query)
        {
            _query = query;
        }
        */


        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(query.Execute(search));
        }

        public IActionResult Post([FromBody]CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            try
            {
                command.Execute(dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
       
    }
}
