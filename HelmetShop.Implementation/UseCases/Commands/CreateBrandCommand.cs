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
    public class CreateBrandCommand : UseCase, ICreateBrandCommand
    {
        private CreateBrandValidator _validator;
        public CreateBrandCommand(HsContext context, CreateBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Create Brand";

        public string Description => "Create brand using EF";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = new Brand
            {
                Name = request.Name
            };

            Context.Brands.Add(brand);

            Context.SaveChanges();
        }
    }
}
