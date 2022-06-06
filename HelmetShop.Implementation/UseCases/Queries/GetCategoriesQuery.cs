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
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        public int Id => 1;

        public string Name => "Search Categories";

        public string Description => "Search Categories using EF";

        private HsContext _context;
        public GetCategoriesQuery(HsContext context) => _context = context;
        
       

        public IEnumerable<CategoryDto> Execute(BaseSearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            return query.Select(x => new CategoryDto
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }

      
    }
}
