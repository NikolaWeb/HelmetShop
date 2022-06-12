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
    public class DeleteProductCommand : UseCase, IDeleteProductCommand
    {
        public DeleteProductCommand(HsContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Delete a product";

        public string Description => "Delete a product using EF";

        public void Execute(int request)
        {
            var product = Context.Products.FirstOrDefault(p => p.Id == request && p.IsActive);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request);
            }

            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}
