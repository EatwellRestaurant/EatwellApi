using EatwellApi.Application.Dtos.Branch;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Branch
{
    public class BranchInsertDtoValidator : AbstractValidator<BranchInsertDto>
    {
        public BranchInsertDtoValidator()
        {
            Include(new BranchUpsertDtoValidator());

            RuleFor(b => b.CityId)
                .NotEmpty()
                .WithMessage("Lütfen bir şehir seçiniz!");
        }
    }
}
