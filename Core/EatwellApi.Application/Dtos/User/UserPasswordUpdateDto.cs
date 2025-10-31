using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.User
{
    public class UserPasswordUpdateDto : IDto
    {
        public string OldPassword { get; set; }
        
        public string NewPassword { get; set; }
        
        public string NewPasswordAgain { get; set; }
    }
}
