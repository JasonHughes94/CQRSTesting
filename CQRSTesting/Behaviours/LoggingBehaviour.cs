using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSTesting.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Pre logic
            _logger.LogInformation("{Request} is starting.", request.GetType().Name);
            var timer = Stopwatch.StartNew();

            //Execute the command/query
            var response = await next();
            timer.Stop();

            //Post logic
            _logger.LogInformation("{Request} has finished in {Time}ms", request.GetType().Name, timer.ElapsedMilliseconds);
            return response;
        }
    }
}