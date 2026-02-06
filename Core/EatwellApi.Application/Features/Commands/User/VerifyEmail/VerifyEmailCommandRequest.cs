using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Commands.User.VerifyEmail
{
    public class VerifyEmailCommandRequest : IRequest<SuccessResponse>
    {
        public int UserId { get; set; }

        public string Code { get; set; }
    }
}
