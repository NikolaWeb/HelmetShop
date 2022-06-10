using FluentValidation;
using HelmetShop.Application.Logging;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using HelmetShop.Implementation;
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
        private UseCaseHandler _handler;

        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        //GET: api/brand
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetBrandsQuery query)
        {    
           
                //var query = _context.Brands.AsQueryable();

                //var keyword = search.Keyword;

                //if (!string.IsNullOrEmpty(keyword))
                //{
                //    query = query.Where(x => x.Name.Contains(keyword));
                //}

                //return Ok(query.Select(x => new BrandDto
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //}).ToList());


            return Ok(_handler.HandleQuery(query, search));
           
            //catch (System.Exception e)
            //{
            //    var guid = Guid.NewGuid();

            //    _logger.Log(e);

            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        new { message = "There was an error processing your request. Contact our support with the following code: " + guid.ToString() });
            //}

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
