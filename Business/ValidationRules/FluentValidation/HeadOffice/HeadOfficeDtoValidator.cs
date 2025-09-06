using Entities.Dtos.HeadOffice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.HeadOffice
{
    public class HeadOfficeDtoValidator : AbstractValidator<HeadOfficeDto>
    {
        public HeadOfficeDtoValidator()
        {
            RuleFor(h => h.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen ana telefon numarasını giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");



            RuleFor(h => h.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen kurumsal e-posta bilgisini giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");



            RuleFor(h => h.Address)
                .NotEmpty()
                .WithMessage("Lütfen şirket adresini giriniz!");

        }
    }
}
