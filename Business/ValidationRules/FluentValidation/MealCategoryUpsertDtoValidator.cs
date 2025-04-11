using Entities.Dtos.MealCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MealCategoryUpsertDtoValidator : AbstractValidator<MealCategoryUpsertDto>
    {
        public MealCategoryUpsertDtoValidator()
        {
            RuleFor(m => m.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Menü ismini giriniz!")
                .MaximumLength(250)
                .WithMessage("Menü ismi en fazla 250 karakter olabilir!");

        }
    }
}
