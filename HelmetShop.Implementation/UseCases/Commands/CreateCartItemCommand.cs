using FluentValidation;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using HelmetShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Commands
{
    public class CreateCartItemCommand : UseCase, ICreateCartItemCommand
    {
        private readonly CreateCartItemValidator _validator;

        public CreateCartItemCommand(HsContext context, CreateCartItemValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 16;

        public string Name => "Put an item in cart";

        public string Description => "Put an item in cart using EF";

        public void Execute(CreateCartItemDto request)
        {
            _validator.ValidateAndThrow(request);

            var cartItem = new CartItem
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity
            };

            Context.CartItems.Add(cartItem);
            Context.SaveChanges();
        }
    }
}
