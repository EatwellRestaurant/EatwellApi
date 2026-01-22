using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Persistence.Services.User
{
    public class UserWriteManager : WriteManager<DomainUser>, IUserWriteService
    {
        public UserWriteManager(IWriteRepository<DomainUser> repository) : base(repository)
        {
        }
    }
}
