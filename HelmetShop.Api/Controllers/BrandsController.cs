using FluentValidation;
using HelmetShop.Api.Extensions;
using HelmetShop.Application.Logging;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using HelmetShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        //GET: api/brands
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch search, [FromServices]IGetBrandsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

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

            //catch (System.Exception e)
            //{
            //    var guid = Guid.NewGuid();

            //    _logger.Log(e);

            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        new { message = "There was an error processing your request. Contact our support with the following code: " + guid.ToString() });
            //}

        }

        [HttpPost]
        public IActionResult Post([FromBody]BrandDto dto, [FromServices]ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
            //try
            //{
            //    //validacija sa ispisom gresaka
            //    //var result = validator.Validate(dto);

            //    //if (!result.IsValid)
            //    //{
            //    //    return result.ToUnprocessableEntity();
            //    //}


            //    //command.Execute(dto);
            //    return StatusCode(201);
            //}
            //catch (ValidationException e)
            //{
            //    return e.Errors.AsUnprocessableEntity();
            //}
            //catch (System.Exception)
            //{
            //    return StatusCode(500);
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteBrandCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
