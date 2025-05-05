using Entities.Dtos.Table;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Table
{
    public class TableUpdateDtoValidator : AbstractValidator<TableUpdateDto>
    {
        public TableUpdateDtoValidator()
        {
            Include(new TableUpsertDtoValidator());
        }
    }
}
