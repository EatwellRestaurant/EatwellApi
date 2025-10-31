using EatwellApi.Application.Dtos.Branch;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Branch
{
    public class BranchUpdateDtoValidator : AbstractValidator<BranchUpdateDto>
    {
        public BranchUpdateDtoValidator()
        {
            Include(new BranchUpsertDtoValidator());
        }
    }
}
