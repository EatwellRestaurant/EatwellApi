using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.User
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
