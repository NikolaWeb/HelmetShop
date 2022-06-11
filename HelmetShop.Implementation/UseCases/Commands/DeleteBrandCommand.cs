using HelmetShop.Application.Exceptions;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Commands
{
    public class DeleteBrandCommand : UseCase, IDeleteBrandCommand
    {
        public DeleteBrandCommand(HsContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Delete brand";

        public string Description => "";

        public void Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand == null)
            {
                throw new EntityNotFoundException(nameof(Brand), request);
            }

            Context.Brands.Remove(brand);
            Context.SaveChanges();
        }
    }
}
