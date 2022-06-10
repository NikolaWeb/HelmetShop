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
    public class GetBrandsQuery : UseCase, IGetBrandsQuery
    {
        public int Id => 2;

        public string Name => "Search Brands";

        public string Description => "Search Brands using EF";


        public GetBrandsQuery(HsContext context) : base(context)
        {
        }

        public IEnumerable<BrandDto> Execute(BaseSearch search)
        {
            var query = Context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            return query.Select(x => new BrandDto
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }

       
    }
}
