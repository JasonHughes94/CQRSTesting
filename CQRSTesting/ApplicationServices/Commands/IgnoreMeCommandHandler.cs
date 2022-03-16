namespace CQRSTesting.ApplicationServices.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class IgnoreMeCommandHandler : IRequestHandler<IgnoreMeCommand>
    {
        private readonly ILogger<IgnoreMeCommand> _logger;

        public IgnoreMeCommandHandler(ILogger<IgnoreMeCommand> logger)
        {
            _logger = logger;
        }

        public Task<Unit> Handle(IgnoreMeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("I should never be hit");
            return Task.FromResult(Unit.Value);
        }
    }
}