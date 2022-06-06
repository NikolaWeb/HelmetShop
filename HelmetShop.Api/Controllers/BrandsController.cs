using HelmetShop.Api.DTO;
using HelmetShop.Api.DTO.Searches;
using HelmetShop.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private HsContext _context;

        public BrandsController(HsContext context)
        {
            _context = context;
        }

        //GET: api/brand
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search)
        {
            try
            {
                var query = _context.Brands.AsQueryable();

                var keyword = search.Keyword;

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(x => x.Name.Contains(keyword));
                }

                return Ok(query.Select(x => new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList());
            }
            catch (System.Exception e)
            {
                var guid = Guid.NewGuid();

                var logger = new ExceptionLogger();

                logger.LogException(e, guid);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "There was an error processing your request. Contact our support with the following code: " + guid.ToString() });
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
