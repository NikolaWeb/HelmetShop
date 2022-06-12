using FluentValidation;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator(HsContext context)
        {

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Type at least 2 characters")
                .Must(x => !context.Products.Any(p => p.Name == x && p.IsActive)).WithMessage("Product {PropertyValue} already exists!");

            RuleFor(x => x.Size).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Size is required")
                .MinimumLength(1).WithMessage("Type at least 1 character");

            RuleFor(x => x.Price).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Price is required");

            RuleFor(x => x.BrandId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BrandId is required");



        }
    }
}
