using HelmetShop.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //GET: api/products
        [HttpGet]
        public IActionResult Get([FromQuery] string keyword)
        {
            var context = new HsContext();

            var productsQuery = context.Products.AsQueryable();

            if(keyword != null)
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(keyword));
            }

            return Ok(productsQuery.Select(x => new
            {
                x.Name,
                x.Description,
                x.Price,
                x.Id,
                Brand = x.Brand.Name
            }).ToList());
        }
    }
}
