using Castle.Core.Internal;
using Entities.Concrete;
using Entities.Dtos.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Branch
{
    public class BranchUpsertDtoValidator : AbstractValidator<BranchUpsertDto>
    {
        public BranchUpsertDtoValidator()
        {
            RuleFor(b => b.Name)
                .Must(b => !b.IsNullOrEmpty())
                .WithMessage("Lütfen şube ismini giriniz!");


            RuleFor(b => b.Address)
                .Must(b => !b.IsNullOrEmpty())
                .WithMessage("Lütfen şubenin adresini giriniz!");


            RuleFor(b => b.Email)
                .Cascade(CascadeMode.Stop)
                .Must(b => !b.IsNullOrEmpty())
                .WithMessage("Lütfen şubenin e-posta adresini giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!")
                .Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");


            RuleFor(b => b.Phone)
                .Cascade(CascadeMode.Stop)
                .Must(b => !b.IsNullOrEmpty())
                .WithMessage("Lütfen şubenin telefon numarasını giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");

        }
    }
}
