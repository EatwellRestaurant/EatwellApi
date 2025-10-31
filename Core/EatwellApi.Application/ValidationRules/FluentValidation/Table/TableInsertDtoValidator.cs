using EatwellApi.Application.Dtos.Table;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Table
{
    public class TableInsertDtoValidator : AbstractValidator<TableInsertDto>
    {
        public TableInsertDtoValidator()
        {
            Include(new TableUpsertDtoValidator());

            RuleFor(t => t.BranchId)
                .NotEmpty()
                .WithMessage("Lütfen bir şube seçiniz!");
        }
    }
}
