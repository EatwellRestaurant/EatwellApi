using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Abstractions.Services.User
{
    public interface IUserReadService : IReadService<DomainUser>
    {
    }
}
