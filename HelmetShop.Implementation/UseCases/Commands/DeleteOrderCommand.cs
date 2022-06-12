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
    public class DeleteOrderCommand : UseCase, IDeleteOrderCommand
    {
        public DeleteOrderCommand(HsContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Delete order";

        public string Description => "";

        public void Execute(int request)
        {
            var order = Context.Orders.Find(request);

            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), request);
            }

            Context.Orders.Remove(order);
            Context.SaveChanges();
        }
    }
}
