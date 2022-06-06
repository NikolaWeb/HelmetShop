using HelmetShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases
{
    public abstract class UseCase
    {
        protected HsContext Context { get; }
        protected UseCase(HsContext context)
        {
            Context = context;
        }
    }
}
