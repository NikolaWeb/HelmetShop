﻿using FluentValidation;
using HelmetShop.Api.Extensions;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UseCaseHandler _handler;

        public RegisterController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterDto dto, [FromServices] IRegisterUserCommand command)
        {
            try
            {
                _handler.HandleCommand(command, dto);

                return StatusCode(201);
            }
            catch (ValidationException e)
            {
                return e.Errors.AsUnprocessableEntity();
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
