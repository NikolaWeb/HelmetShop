using HelmetShop.Application.Exceptions;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Queries
{
    public class GetProductQuery : UseCase, IGetProductQuery
    {
        public GetProductQuery(HsContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get a product by ID";

        public string Description => "Only one product";

        public ProductDto Execute(int search)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == search && x.IsActive);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), search);
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Size = product.Size,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                BrandId = product.BrandId
            };
        }
    }
}
