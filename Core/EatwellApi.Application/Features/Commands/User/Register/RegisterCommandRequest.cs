using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Commands.User.Register
{
    public class RegisterCommandRequest : IRequest<CreateSuccessResponse>
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
