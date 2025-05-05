using Entities.Dtos.Table;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Table
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
