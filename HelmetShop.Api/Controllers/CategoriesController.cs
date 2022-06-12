using FluentValidation;
using HelmetShop.Api.Extensions;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.Implementation;
using HelmetShop.Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /*
        private IGetCategoriesQuery _query;

        public CategoriesController(IGetCategoriesQuery query)
        {
            _query = query;
        }
        */

        /// <summary>
        /// Search categories
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>

        // GET: api/<CategoriesController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetCategoriesQuery query)
        {
            //return Ok(query.Execute(search));

            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        
        public IActionResult Post([FromBody]CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            //command.Execute(dto);
            return StatusCode(201);
            //try
            //{
            //    //validacija sa ispisom gresaka
            //    //var result = validator.Validate(dto);

            //    //if (!result.IsValid)
            //    //{
            //    //    return result.ToUnprocessableEntity();
            //    //}


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
       
    }
}
