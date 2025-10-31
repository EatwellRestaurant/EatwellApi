using EatwellApi.Application.Dtos.Table;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Table
{
    public class TableUpdateDtoValidator : AbstractValidator<TableUpdateDto>
    {
        public TableUpdateDtoValidator()
        {
            Include(new TableUpsertDtoValidator());
        }
    }
}
