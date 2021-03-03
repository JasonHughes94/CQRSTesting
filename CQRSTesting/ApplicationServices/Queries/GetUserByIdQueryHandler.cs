using System.Threading;
using System.Threading.Tasks;
using CQRSTesting.Domain.Models;
using MediatR;

namespace CQRSTesting.ApplicationServices.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new User(1, "Test", new[] {"SysAdmin"}));
        }
    }
}