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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private HsContext _context;
        public CreateCategoryValidator(HsContext context)
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name cannot be empty")
                                .MinimumLength(2).WithMessage("Type at least 2 characters")
                                .Must(CategoryExists).WithMessage("Category {PropertyValue} already exists!");
            _context = context;
        }

        private bool CategoryExists(string name)
        {
            return !_context.Categories.Any(x => x.Name == name);
        }

    }
}
