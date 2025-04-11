using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
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
