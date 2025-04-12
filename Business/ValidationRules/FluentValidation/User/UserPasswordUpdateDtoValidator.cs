using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.User
{
    public class UserPasswordUpdateDtoValidator : AbstractValidator<UserPasswordUpdateDto>
    {
        public UserPasswordUpdateDtoValidator()
        {
            RuleFor(u => u.OldPassword)
                .NotEmpty()
                .WithMessage("Lütfen mevcut şifrenizi giriniz!");


            RuleFor(u => u.NewPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen yeni şifrenizi giriniz!")
                .MinimumLength(8)
                .WithMessage("Yeni şifrenizin uzunluğu en az 8 karakter olmalıdır!")
                .MaximumLength(16)
                .WithMessage("Yeni şifrenizin uzunluğu en fazla 16 karakter olmalıdır!");
            
            
            RuleFor(u => u.NewPasswordAgain)
                .NotEmpty()
                .WithMessage("Lütfen yeni şifrenizi tekrar giriniz!");
        }
    }
}
