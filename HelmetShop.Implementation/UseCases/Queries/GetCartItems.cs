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
    public class GetCartItemsQuery : UseCase, IGetCartItemsQuery
    {
        public GetCartItemsQuery(HsContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Search cart items";

        public string Description => "Search cart items using EF";

        public Pagination<CartItemDto> Execute(BasePaginationSearch search)
        {
            var query = Context.CartItems.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.ProductId != 0);
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

            var response = new Pagination<CartItemDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new CartItemDto
            {
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                OrderId = x.OrderId
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }

    }
}
