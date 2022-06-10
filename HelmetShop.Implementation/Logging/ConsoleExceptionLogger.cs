using HelmetShop.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception e)
        {
            Console.WriteLine("Happened at: " + DateTime.UtcNow + " Message: " + e.Message);
        }
    }
}
