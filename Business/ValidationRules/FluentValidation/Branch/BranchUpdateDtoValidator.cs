using Entities.Dtos.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Branch
{
    public class BranchUpdateDtoValidator : AbstractValidator<BranchUpdateDto>
    {
        public BranchUpdateDtoValidator()
        {
            Include(new BranchUpsertDtoValidator());
        }
    }
}
