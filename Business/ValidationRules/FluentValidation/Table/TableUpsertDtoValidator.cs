using Castle.Core.Internal;
using Entities.Dtos.Table;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Table
{
    public class TableUpsertDtoValidator : AbstractValidator<TableUpsertDto>
    {
        public TableUpsertDtoValidator()
        {
            RuleFor(t => t.Name)
                 .Cascade(CascadeMode.Stop)
                 .Must(t => !t.IsNullOrEmpty())
                 .WithMessage("Lütfen masa ismini giriniz!")
                 .MaximumLength(50)
                 .WithMessage("Masa isminin uzunluğu en fazla 50 karakter olmalıdır!");


            RuleFor(t => t.TableNo)
                .GreaterThan(0)
                .WithMessage("Masa numarası sıfırdan büyük olmalıdır!");


            RuleFor(t => t.Capacity)
                .Must(t => t > 0 && t < 21)
                .WithMessage("Sadece 1 ila 20 kişi arasında masa oluşturabilirsiniz!");
        }
    }
}
