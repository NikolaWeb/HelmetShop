using HelmetShop.Application.UseCases;
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

        Pagination<ProductDto> IQuery<BasePaginationSearch, Pagination<ProductDto>>.Execute(BasePaginationSearch search)
        {
            var query = Context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.Page = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;


            var response = new Pagination<ProductDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ProductDto
            {
                Name = x.Name,
                Size = x.Size,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Id = x.Id,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }

        
    }
}
