using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.User
{
    public class UserUpdateDto : IDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
