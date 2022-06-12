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
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        private HsContext _context;
        public CreateOrderValidator(HsContext context)
        {
            RuleFor(x => x.Address).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Address can not be empty")
                                .MinimumLength(5).WithMessage("Type at least 5 characters");

            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("UserId can not be empty");
                                

        }

      

    }
}
