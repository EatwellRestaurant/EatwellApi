using EatwellApi.Application.Dtos.Table;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Table
{
    public class TableUpsertDtoValidator : AbstractValidator<TableDto>
    {
        public TableUpsertDtoValidator()
        {
            RuleFor(t => t.Name)
                 .Cascade(CascadeMode.Stop)
                 .Must(t => !string.IsNullOrEmpty(t))
                 .WithMessage("Lütfen masa ismini giriniz!")
                 .MaximumLength(50)
                 .WithMessage("Masa isminin uzunluğu en fazla 50 karakter olmalıdır!");


            RuleFor(t => t.No)
                .GreaterThan(0)
                .WithMessage("Masa numarası sıfırdan büyük olmalıdır!");


            RuleFor(t => t.Capacity)
                .Must(t => t > 0 && t < 21)
                .WithMessage("Sadece 1 ila 20 kişi arasında masa oluşturabilirsiniz!");
        }
    }
}
