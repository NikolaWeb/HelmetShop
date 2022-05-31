using HelmetShop.Api.DTO;
using HelmetShop.Api.DTO.Searches;
using HelmetShop.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static HelmetShop.Api.Extensions.StringExtensions;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private HsContext _context;

        public BrandController()
        {
            _context = new HsContext();
        }

        //GET: api/brand
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search)
        {
            var query = _context.Brands.AsQueryable();

            var keyword = search.Keyword;

            if (NotNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            return Ok(query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
