using EatwellApi.Application.Dtos.ShiftDay;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.ShiftDay
{
    public class ShiftDayDtoValidator : AbstractValidator<ShiftDayDto>
    {
        public ShiftDayDtoValidator()
        {
            RuleFor(s => s.ShiftId)
                .Must(s => s > 0 && s < 8)
                .WithMessage("Lütfen geçerli bir gün seçin!");



            RuleFor(s => s.StartTime)
                .NotEmpty()
                .When(s => s.EndTime.HasValue)
                .WithMessage("Lütfen çalışma günü başlangıç saatini giriniz!");



            RuleFor(s => s.EndTime)
                .NotEmpty()
                .When(s => s.StartTime.HasValue)
                .WithMessage("Lütfen çalışma günü bitiş saatini giriniz!");



            When(s => s.StartTime.HasValue && s.EndTime.HasValue, () =>
            {
                RuleFor(s => s.IsHoliday)
                    .Must(s => s == false)
                    .WithMessage("Çalışma günü girildiği için 'Tatil' seçilemez.");


                RuleFor(s => s.IsLeave)
                    .Must(s => s == false)
                    .WithMessage("Çalışma günü girildiği için 'İzinli' seçilemez.");
            });



            When(s => s.IsHoliday == false && s.IsLeave == false, () =>
            {
                RuleFor(s => s.StartTime)
                    .NotEmpty()
                    .WithMessage("Lütfen çalışma günü başlangıç saatini giriniz!");



                RuleFor(s => s.EndTime)
                    .NotEmpty()
                    .WithMessage("Lütfen çalışma günü bitiş saatini giriniz!");
            });
        }
    }
}
