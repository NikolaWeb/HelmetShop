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
    public class CreateProductCommand : UseCase, ICreateProductCommand
    {
        private readonly CreateProductValidator _validator;

        public CreateProductCommand(HsContext context, CreateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Create a product";

        public string Description => "";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                Name = request.Name,
                Size = request.Size,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                BrandId = request.BrandId,
            };

            Context.Products.Add(product);
            Context.SaveChanges();
        }
    }
}
