using HelmetShop.Application;
using HelmetShop.Application.Logging;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using HelmetShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
       
       
        private UseCaseHandler _handler;

        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        //GET: api/products
        [HttpGet]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetProductsQuery query)
        {
          
            return Ok(_handler.HandleQuery(query, search));
        }

        //GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetProductQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        //POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
           
            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

        //DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }


    //GET: api/products

    //[HttpGet]
    //public IActionResult Get([FromQuery] string keyword)
    //{

    //    var productsQuery = _context.Products.AsQueryable();

    //    if(keyword != null)
    //    {
    //        productsQuery = productsQuery.Where(x => x.Name.Contains(keyword));
    //    }

    //    return Ok(productsQuery.Select(x => new
    //    {
    //        x.Name,
    //        x.Size,
    //        x.Description,
    //        x.Price,
    //        x.Id,
    //        Brand = x.Brand.Name
    //    }).ToList());
    //}


}
