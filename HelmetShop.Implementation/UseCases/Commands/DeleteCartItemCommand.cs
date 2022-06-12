using HelmetShop.Application.Exceptions;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Commands
{
    public class DeleteCartItemCommand : UseCase, IDeleteCartItemCommand
    {
        public DeleteCartItemCommand(HsContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Delete an item from cart";

        public string Description => "Delete an item from cart using EF";

        public void Execute(int request)
        {
            var cartItem = Context.CartItems.FirstOrDefault(p => p.OrderId == request);

            if (cartItem == null)
            {
                throw new EntityNotFoundException(nameof(CartItem), request);
            }

            Context.CartItems.Remove(cartItem);
            Context.SaveChanges();
        }
    }
}
