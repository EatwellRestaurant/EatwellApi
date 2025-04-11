using Entities.Dtos.User;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!")
                .Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");



            RuleFor(u => u.Password)
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
