using EatwellApi.Application.Features.Commands.User.Register;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EatwellApi.Application.ValidationRules.FluentValidation.User
{
    public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestValidator()
        {
            RuleFor(r => r.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen isminizi giriniz!")
                .MaximumLength(50)
                .WithMessage("İsminizin uzunluğu en fazla 50 karakter olmalıdır!");



            RuleFor(r => r.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen soy isminizi giriniz!")
                .MaximumLength(50)
                .WithMessage("Soy isminizin uzunluğu en fazla 50 karakter olmalıdır!");



            RuleFor(r => r.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!")
                .Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");



            RuleFor(r => r.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen şifrenizi giriniz!")
                .MinimumLength(8)
                .WithMessage("Şifrenizin uzunluğu en az 8 karakter olmalıdır!")
                .MaximumLength(16)
                .WithMessage("Şifrenizin uzunluğu en fazla 16 karakter olmalıdır!");
            //.Matches(@"[A-Z]+")
            //.WithMessage("Şifreniz en az bir büyük harf içermelidir!")
            //.Matches(@"[a-z]+")
            //.WithMessage("Şifreniz en az bir küçük harf içermelidir!")
            //.Matches(@"[0-9]+")
            //.WithMessage("Şifreniz en az bir sayı içermelidir!");
        }
    }
}
