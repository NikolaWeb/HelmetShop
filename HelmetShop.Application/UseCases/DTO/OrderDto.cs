using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.UseCases.DTO
{
    public class OrderDto : BaseDto
    { 
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderLineId { get; set; }
    }
}
