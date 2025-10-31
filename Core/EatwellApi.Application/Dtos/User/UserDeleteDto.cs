using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.User
{
    public class UserDeleteDto : IDto
    {
        public string Password { get; set; }
    }
}
