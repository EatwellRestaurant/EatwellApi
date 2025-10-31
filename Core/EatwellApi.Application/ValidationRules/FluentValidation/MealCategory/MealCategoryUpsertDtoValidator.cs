using EatwellApi.Application.Dtos.MealCategory;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.MealCategory
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
