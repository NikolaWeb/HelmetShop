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
    public class CreateBrandValidator : AbstractValidator<BrandDto>
    {
        private HsContext _context;
        public CreateBrandValidator(HsContext context)
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name cannot be empty")
                                .MinimumLength(2).WithMessage("Type at least 2 characters")
                                .Must(BrandExists).WithMessage("Brand {PropertyValue} already exists!");
            _context = context;
        }

        private bool BrandExists(string name)
        {
            return !_context.Brands.Any(x => x.Name == name);
        }

    }
}
