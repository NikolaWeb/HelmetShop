using HelmetShop.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.UseCaseLoggers
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(UseCaseLogger log)
        {
            Console.WriteLine($"UseCase: {log.UseCaseName}, User: {log.User}, {log.ExecutionTime}, Authorization: {log.IsAuthorized}");
            Console.WriteLine($"Use case data:" + log.Data);
        }
    }
}
