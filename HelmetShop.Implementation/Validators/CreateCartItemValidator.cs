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
    public class CreateCartItemValidator : AbstractValidator<CreateCartItemDto>
    {
        private HsContext _context;
       

        public CreateCartItemValidator(HsContext context)
        {
            RuleFor(x => x.ProductId).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("ProductId can not be empty");

            RuleFor(x => x.OrderId).Cascade(CascadeMode.Stop)
                                    .NotEmpty().WithMessage("OrderId can not be empty");

            RuleFor(x => x.Quantity).Cascade(CascadeMode.Stop)
                                    .NotEmpty().WithMessage("Quantity can not be empty")
                                    .Must(x => x > 0).WithMessage("Quantity has to be 1 or more");
        }
    }
}
