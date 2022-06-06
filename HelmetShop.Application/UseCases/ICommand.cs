using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.UseCases
{
    public interface ICommand<Trequest> : IUseCase
    {
        void Execute(Trequest request);
    }
}
