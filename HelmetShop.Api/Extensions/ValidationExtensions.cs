using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelmetShop.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var error = result.Errors.Select(x => new
            {
                x.ErrorMessage,
                x.PropertyName
            });

            return new UnprocessableEntityObjectResult(error);
        }
    }
}
