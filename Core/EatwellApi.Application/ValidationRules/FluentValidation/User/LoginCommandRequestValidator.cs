using EatwellApi.Application.Features.Commands.User.Login;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.User
{
    public class LoginCommandRequestValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandRequestValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi giriniz!");


            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Lütfen şifrenizi giriniz!");
        }
    }
}
