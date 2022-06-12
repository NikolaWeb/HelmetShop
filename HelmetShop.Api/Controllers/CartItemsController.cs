using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartItemsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CartItemsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetCartItemsQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }

        //POST: api/cartitems
        [HttpPost]
        public IActionResult Post([FromBody] CreateCartItemDto dto, [FromServices] ICreateCartItemCommand command)
        {

            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

        //DELETE: api/cartitems/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCartItemCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
