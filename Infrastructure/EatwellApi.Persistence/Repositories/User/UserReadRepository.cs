using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Persistence.Context;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Persistence.Repositories.User
{
    public class UserReadRepository : ReadRepository<DomainUser>, IUserReadRepository
    {
        public UserReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
