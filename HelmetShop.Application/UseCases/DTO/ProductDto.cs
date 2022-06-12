using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.UseCases.DTO
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
    }
}
