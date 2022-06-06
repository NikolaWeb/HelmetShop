using HelmetShop.Application.UseCases.DTO;
using HelmetShop.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.UseCases.Queries
{
    public interface IGetCategoriesQuery : IQuery<BaseSearch, IEnumerable<CategoryDto>>
    {

    }
}
