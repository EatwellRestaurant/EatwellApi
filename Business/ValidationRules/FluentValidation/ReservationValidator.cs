using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Email).Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Email adresi geçerli değil!");

            RuleFor(r => r.Phone).NotEmpty().WithMessage("Telefon numarası zorunludur!");
            RuleFor(r => r.Phone).Matches(
                new Regex(@"\+90 \d{3} \d{3} \d{2} \d{2}|0\d{3}\ \d{3} \d{2} \d{2}|\d{4} \d{2} \d{2}"))
                .WithMessage("Telefon numarası geçerli değil!");

        }
    }
}
