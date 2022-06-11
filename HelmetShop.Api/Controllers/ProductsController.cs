using HelmetShop.DataAccess;
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
        private HsContext _context;

        public ProductsController(HsContext context)
        {
            _context = context;
        }

        //GET: api/products
        [HttpGet]
        public IActionResult Get([FromQuery] string keyword)
        {
           
            var productsQuery = _context.Products.AsQueryable();

            if(keyword != null)
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(keyword));
            }

            return Ok(productsQuery.Select(x => new
            {
                x.Name,
                x.Size,
                x.Description,
                x.Price,
                x.Id,
                Brand = x.Brand.Name
            }).ToList());
        }
    }
}
