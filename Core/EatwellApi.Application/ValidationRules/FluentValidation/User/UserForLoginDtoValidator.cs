using EatwellApi.Application.Dtos.User;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.User
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi giriniz!");


            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Lütfen şifrenizi giriniz!");
        }
    }
}
