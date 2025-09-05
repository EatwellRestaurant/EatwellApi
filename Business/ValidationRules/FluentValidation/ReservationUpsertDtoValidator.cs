using Entities.Concrete;
using Entities.Dtos.Reservation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ReservationUpsertDtoValidator : AbstractValidator<ReservationUpsertDto>
    {
        public ReservationUpsertDtoValidator()
        {
            RuleFor(r => r.FullName)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .WithMessage("Lütfen isminizi giriniz!")
                 .MaximumLength(85)
                 .WithMessage("İsminizin uzunluğu en fazla 85 karakter olmalıdır!");


            RuleFor(r => r.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi giriniz!")
                .NotNull()
                .WithMessage("Lütfen e-posta adresinizi giriniz!")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!")
                .Matches(new Regex(@"\w+\.com$"))
                .WithMessage("Lütfen geçerli bir e-posta adresi giriniz!");



            RuleFor(r => r.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Lütfen telefon numaranızı giriniz!")
                .Matches(new Regex(@"0\d{3}\ \d{3} \d{2} \d{2}"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz!");



            RuleFor(r => r.ReservationDate)
                .Must(r => r >= DateTime.Now)
                .WithMessage("Geçmiş bir tarih için rezervasyon oluşturamazsınız.");



            RuleFor(r => r.PersonCount)
                .Must(r => r > 0 && r < 21)
                .WithMessage("Sadece 1 ila 20 kişi arasında rezervasyon oluşturabilirsiniz.");
        }
    }
}
