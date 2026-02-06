using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Constants.Messages.Entity;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.User;
using EatwellApi.Domain.Security;
using MediatR;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Features.Commands.User.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, DataResponse<AccessToken>>
    {
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<DataResponse<AccessToken>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            DomainUser? user = await _userService.GetByEmailAsync(request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new InvalidCredentialsException();


            if (user.Verification != true)
                throw new EmailNotVerifiedException();


            DataResponse<AccessToken> dataResponse = _userService.CreateAccessToken(user);
            user.LastLoginDate = DateTime.Now;


            await _unitOfWork.SaveChangesAsync();
            return new DataResponse<AccessToken>(dataResponse.Data, AuthMessages.SuccessfulLogin);
        }
    }
}
