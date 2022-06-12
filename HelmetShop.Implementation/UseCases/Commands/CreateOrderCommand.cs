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
    public class CreateOrderCommand : UseCase, ICreateOrderCommand
    {
        private readonly CreateOrderValidator _validator;
        public CreateOrderCommand(HsContext context, CreateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Category";

        public string Description => "Create category using EF";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                Address = request.Address,
                UserId = request.UserId,
                CreatedAt = request.CreatedAt,
            };

            Context.Orders.Add(order);

            Context.SaveChanges();
        }
    }
}
