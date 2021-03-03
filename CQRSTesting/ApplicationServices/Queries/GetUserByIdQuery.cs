using CQRSTesting.Caching;
using CQRSTesting.Domain.Models;
using MediatR;

namespace CQRSTesting.ApplicationServices.Queries
{
    public class GetUserByIdQuery : IRequest<User>, ICacheable
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string CacheKey => $"GetUserByUd-{Id}";
    }
}