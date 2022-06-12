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
    public class GetCategoriesQuery : UseCase, IGetCategoriesQuery
    {
        public int Id => 1;

        public string Name => "Search Categories";

        public string Description => "Search Categories using EF";

       
        public GetCategoriesQuery(HsContext context) : base(context)
        {
        }

        public Pagination<CategoryDto> Execute(BasePaginationSearch search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            if(search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.Page = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;


            var response = new Pagination<CategoryDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new CategoryDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;

            //return query.Select(x => new CategoryDto
            //{
            //    Name = x.Name,
            //    Id = x.Id,
            //}).ToList();
        }

      
    }
}
