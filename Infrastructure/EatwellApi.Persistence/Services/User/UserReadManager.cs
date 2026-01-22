using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Persistence.Services.User
{
    public class UserReadManager : ReadManager<DomainUser>, IUserReadService
    {
        public UserReadManager(IReadRepository<DomainUser> repository) : base(repository)
        {
        }
    }
}
