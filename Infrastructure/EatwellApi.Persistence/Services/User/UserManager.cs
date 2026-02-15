using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using EatwellApi.Domain.Exceptions.General;
using EatwellApi.Domain.Security;
using Microsoft.EntityFrameworkCore;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Persistence.Services.User
{
    public class UserManager : IUserService
    {
        readonly IUserReadRepository _userReadRepository;
        readonly ITokenHelper _tokenHelper;

        
        public UserManager(IUserReadRepository userReadRepository, ITokenHelper tokenHelper)
        {
            _userReadRepository = userReadRepository;
            _tokenHelper = tokenHelper;
        }



        public async Task CheckIfUserEMailAsync(string email)
        {
            if (await _userReadRepository.AnyAsync(u => u.Email == email && !u.IsDeleted))
                throw new EntityAlreadyExistsException("e-posta");
        }



        public async Task<DomainUser?> GetByEmailAsync(string email)
            => await _userReadRepository
                .Where(u => u.Email == email && !u.IsDeleted)
                .Include(u => u.OperationClaim)
                .SingleOrDefaultAsync();



        public async Task<DomainUser> GetByIdAsync(int id)
            => await _userReadRepository
            .Where(u => u.Id == id && !u.IsDeleted)
            .SingleOrDefaultAsync() ?? 
            throw new EntityNotFoundException("Kullanıcı");
        


        public DataResponse<AccessToken> CreateAccessToken(DomainUser user)
            => new DataResponse<AccessToken>
            (_tokenHelper.CreateToken(user, user.OperationClaim.Name));



        public async Task<int> CountUsersByClaimAsync(OperationClaimEnum claimEnum)
            => await _userReadRepository.CountAsync(u => u.OperationClaimId == (int)claimEnum && !u.IsDeleted);


    }
}
