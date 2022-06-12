using HelmetShop.Api.Payment;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
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
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetOrdersQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        //DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
