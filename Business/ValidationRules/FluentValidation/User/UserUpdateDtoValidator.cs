using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.User
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen isminizi giriniz!")
                .MaximumLength(50)
                .WithMessage("İsminizin uzunluğu en fazla 50 karakter olmalıdır!");


            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen soy isminizi giriniz!")
                .MaximumLength(50)
                .WithMessage("Soy isminizin uzunluğu en fazla 50 karakter olmalıdır!");


            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Lütfen şifrenizi giriniz!");
        }
    }
}
