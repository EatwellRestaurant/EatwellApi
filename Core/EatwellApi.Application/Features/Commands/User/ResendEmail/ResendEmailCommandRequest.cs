using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Commands.User.ResendEmail
{
    public class ResendEmailCommandRequest : IRequest<SuccessResponse>
    {
        public int UserId { get; set; }
    }
}
