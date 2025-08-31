using Entities.Dtos.HeadOffice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.HeadOffice
{
    public class HeadOfficeDtoValidator : AbstractValidator<HeadOfficeDto>
    {
        public HeadOfficeDtoValidator()
        {
            RuleFor(h => h.Phone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Lütfen ana telefon numarasını giriniz!")
                .NotEmpty()
                .WithMessage("Lütfen ana telefon numarasını giriniz!");
            
            

            RuleFor(h => h.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Lütfen kurumsal e-posta bilgisini giriniz!")
                .NotEmpty()
                .WithMessage("Lütfen kurumsal e-posta bilgisini giriniz!");
            
            
            
            RuleFor(h => h.Address)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Lütfen şirket adresini giriniz!")
                .NotEmpty()
                .WithMessage("Lütfen şirket adresini giriniz!");

        }
    }
}
