using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using EatwellApi.Domain.Security;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task CheckIfUserEMailAsync(string email);

        Task<DomainUser?> GetByEmailAsync(string email);

        Task<DomainUser> GetByIdAsync(int id);

        DataResponse<AccessToken> CreateAccessToken(DomainUser user);

        Task<int> CountUsersByClaimAsync(OperationClaimEnum claimEnum);
    }
}
