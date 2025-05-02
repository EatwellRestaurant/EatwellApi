using Entities.Dtos.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Branch
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
