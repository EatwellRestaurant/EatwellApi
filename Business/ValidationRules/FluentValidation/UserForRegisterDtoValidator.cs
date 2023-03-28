using Entities.Dtos;
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
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Email adresi geçerli değil!");

            RuleFor(u => u.Phone).NotEmpty().WithMessage("Telefon numarası zorunludur!");
            RuleFor(u => u.Phone).Matches(
                new Regex(@"\+90 \d{3} \d{3} \d{2} \d{2}|0\d{3}\ \d{3} \d{2} \d{2}|\d{4} \d{2} \d{2}"))
                .WithMessage("Telefon numarası geçerli değil!");

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("Şifrenizin uzunluğu en az 8 karakter olmalıdır!");
            RuleFor(u => u.Password).MaximumLength(16).WithMessage("Şifrenizin uzunluğu en fazla 16 karakter olmalıdır!");
            RuleFor(u => u.Password).Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermelidir!");
            RuleFor(u => u.Password).Matches(@"[a-z]+").WithMessage("Şifreniz küçük harf içermemelidir");
            RuleFor(u => u.Password).Matches(@"[0-9]+").WithMessage("Parolanız en az bir sayı içermelidir!");
            RuleFor(u => u.Password).Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz en az bir tane (! ? * .) içermelidir!");
        }
    }
}
