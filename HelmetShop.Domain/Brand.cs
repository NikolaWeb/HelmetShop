using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Domain
{
    public class Brand : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
