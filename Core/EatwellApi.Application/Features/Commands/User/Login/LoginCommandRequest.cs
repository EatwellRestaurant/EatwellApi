using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Security;
using MediatR;

namespace EatwellApi.Application.Features.Commands.User.Login
{
    public class LoginCommandRequest : IRequest<DataResponse<AccessToken>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
