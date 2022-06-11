using HelmetShop.Application;
using HelmetShop.Application.Logging;
using HelmetShop.Application.UseCases;
using HelmetShop.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;

        public UseCaseHandler(IExceptionLogger logger, IApplicationUser user, IUseCaseLogger useCaseLogger)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
        }

        //rad sa komandama
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);

                var sp = new Stopwatch();
                sp.Start();

                command.Execute(data);

                sp.Stop();

                Console.WriteLine(command.Name + " Duration: " + sp.ElapsedMilliseconds + "ms");
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
                HandleLoggingAndAuthorization(query, data);

                var sp = new Stopwatch();
                sp.Start();

                var response = query.Execute(data);

                sp.Stop();

                Console.WriteLine(query.Name + " Duration: " + sp.ElapsedMilliseconds + "ms");

                return response;
            }
            catch (Exception e)
            {

                _logger.Log(e);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var log = new UseCaseLogger
            {
                User = _user.Identity,
                ExecutionTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = _user.UseCaseIds.Contains(useCase.Id)
            };

            _useCaseLogger.Log(log);

            if (!log.IsAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            }
        }
    }
}
