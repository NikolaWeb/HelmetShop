using HelmetShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.UseCases.Queries
{
    public interface IGetProductQuery : IQuery<int, ProductDto>
    {
    }
}
