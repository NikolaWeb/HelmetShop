using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Domain
{
    public class Order : Entity
    {
        public string Address { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
