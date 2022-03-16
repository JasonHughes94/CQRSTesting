using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CQRSTesting.Behaviours
{
    using System;
    using System.Collections.Generic;

    public class StoppingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly List<string> ExclusionList = new() { "IgnoreMeCommand" };

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (ExclusionList.Contains(request.GetType().Name))
            {
                return default;
            }

            return await next();
        }
    }
}