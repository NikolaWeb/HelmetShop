using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Queries
{
    public class GetProductsQuery : UseCase, IGetProductsQuery
    {
        public GetProductsQuery(HsContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Search products";

        public string Description => "Search products using EF";

        public IEnumerable<ProductDto> Execute(BaseSearch search)
        {
            var query = Context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            return query.Select(x => new ProductDto
            {
                Name = x.Name,
                Size = x.Size,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Id = x.Id,
                BrandId = x.BrandId
            }).ToList();
        }
    }
}
