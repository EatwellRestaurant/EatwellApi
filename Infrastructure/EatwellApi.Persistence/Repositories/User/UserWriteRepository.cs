using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Persistence.Context;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Persistence.Repositories.User
{
    public class UserWriteRepository : WriteRepository<DomainUser>, IUserWriteRepository
    {
        public UserWriteRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
