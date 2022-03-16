using System.Threading;
using System.Threading.Tasks;
using CQRSTesting.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CQRSTesting.Behaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachingBehaviour<TRequest, TResponse>> _logger;

        public CachingBehaviour(IMemoryCache cache, ILogger<CachingBehaviour<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Pre logic
            var requestName = request.GetType();
            _logger.LogInformation("{Request} is configured for caching", requestName);

            if (_cache.TryGetValue(request.CacheKey, out TResponse response))
            {
                _logger.LogInformation("Returning cached value for {Request}", requestName);
                return response;
            }

            //Execute the Command/Query
            _logger.LogInformation("{Request} cache key: {Key} is not in the cache, executing request.", requestName, request.CacheKey);
            response = await next();

            //Post logic
            _cache.Set(request.CacheKey, response);

            return response;
        }
    }
}