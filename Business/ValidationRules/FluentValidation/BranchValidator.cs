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
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(b => b.Phone).NotEmpty().WithMessage("Telefon numarası zorunludur!");
            RuleFor(b => b.Phone).Matches(
                new Regex(@"\+90 \d{3} \d{3} \d{2} \d{2}|0\d{3}\ \d{3} \d{2} \d{2}|\d{4} \d{2} \d{2}"))
                .WithMessage("Telefon numarası geçerli değil!");
            RuleFor(b => b.Name).MinimumLength(2);
        }
    }
}
