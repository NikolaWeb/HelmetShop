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
    public class UpdateUserUseCasesValidator : AbstractValidator<UpdateUserUseCasesDto>
    {
        public UpdateUserUseCasesValidator(HsContext context)
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User is required")
                .Must(x => context.Users.Any(u => u.Id == x && u.IsActive)).WithMessage("User does not exist");

            RuleFor(x => x.UseCaseIds)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Use cases are required")
               .Must(x => x.Count() == x.Distinct().Count()).WithMessage("Duplicate values are not allowed");

        }
    }
}
