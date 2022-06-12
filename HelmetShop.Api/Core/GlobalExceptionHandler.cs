using FluentValidation;
using HelmetShop.Application;
using HelmetShop.Application.Exceptions;
using HelmetShop.Application.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace HelmetShop.Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;

        public GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception e)
            {
                _logger.Log(e);

                context.Response.ContentType = "application/json";

                object response = null;

                var statusCode = StatusCodes.Status500InternalServerError;

                if (e is ForbiddenUseCaseExecutionException)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }

                if (e is EntityNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }
                if (e is ValidationException validationException)
                {
                    statusCode |= StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = validationException.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }

                if (e is UseCaseConflictException conflictException)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new { message = conflictException.Message };
                }

                context.Response.StatusCode = statusCode;
                
                if(response != null) { 
                    await context.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
