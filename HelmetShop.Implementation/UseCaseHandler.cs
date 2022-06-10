using HelmetShop.Application.Logging;
using HelmetShop.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;

        public UseCaseHandler(IExceptionLogger logger)
        {
            _logger = logger;
        }

        //rad sa komandama
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                command.Execute(data);

                Console.WriteLine(command.Name);
            }
            catch (Exception e)
            {

                _logger.Log(e);
                throw;
            }
        }

        //rad sa upitima
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                var response = query.Execute(data);

                Console.WriteLine(query.Name);

                return response;
            }
            catch (Exception e)
            {

                _logger.Log(e);
                throw;
            }
        }
    }
}
