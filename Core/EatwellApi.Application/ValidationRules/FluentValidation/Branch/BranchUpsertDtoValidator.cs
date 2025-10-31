using EatwellApi.Application.Dtos.Branch;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Branch
{
    public class BranchUpsertDtoValidator : AbstractValidator<BranchUpsertDto>
    {
        public BranchUpsertDtoValidator()
        {
            RuleFor(b => b.Name)
                .Must(b => !string.IsNullOrEmpty(b))
                .WithMessage("Lütfen şube ismini giriniz!");


            RuleFor(b => b.Address)
                .Must(b => !string.IsNullOrEmpty(b))
                .WithMessage("Lütfen şubenin adresini giriniz!");


            RuleFor(b => b.Email)
                .Cascade(CascadeMode.Stop)
                .Must(b => !string.IsNullOrEmpty(b))
                .WithMessage("Lütfen şubenin e-posta adresini giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!")
                .Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");


            RuleFor(b => b.Phone)
                .Cascade(CascadeMode.Stop)
                .Must(b => !string.IsNullOrEmpty(b))
                .WithMessage("Lütfen şubenin telefon numarasını giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");

        }
    }
}
