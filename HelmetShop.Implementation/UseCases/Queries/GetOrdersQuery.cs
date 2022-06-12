using HelmetShop.Application.Exceptions;
using HelmetShop.Application.UseCases;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
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
    public class GetOrdersQuery : UseCase, IGetOrdersQuery
    {
        public GetOrdersQuery(HsContext context) : base(context)
        {

        }

        public int Id => 15;

        public string Name => "Search orders";

        public string Description => "Search orders using EF";

        Pagination<OrderDto> IQuery<BasePaginationSearch, Pagination<OrderDto>>.Execute(BasePaginationSearch search)
        {
            var query = Context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Address.Contains(search.Keyword));
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


            var response = new Pagination<OrderDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new OrderDto
            {
                Id = x.Id,
                Address = x.Address,
                UserId = x.UserId,
                CreatedAt = x.CreatedAt,                
                User = x.User.Username
               
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
