using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Domain.Exceptions.General;

namespace EatwellApi.Persistence.Services.User
{
    public class UserManager : IUserService
    {
        readonly IUserReadRepository _userReadRepository;

        public UserManager(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }



        public async Task CheckIfUserEMailAsync(string email)
        {
            if (await _userReadRepository.AnyAsync(u => u.Email == email && !u.IsDeleted))
                throw new EntityAlreadyExistsException("e-posta");
        }
    }
}
