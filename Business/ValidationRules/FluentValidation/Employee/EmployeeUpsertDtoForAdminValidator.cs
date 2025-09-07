using Entities.Dtos.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Employee
{
    public class EmployeeUpsertDtoForAdminValidator : AbstractValidator<EmployeeUpsertDtoForAdmin>
    {
        public EmployeeUpsertDtoForAdminValidator()
        {
            Include(new EmployeeUpsertDtoValidator());


            RuleFor(e => e.BranchId)
                .NotEmpty()
                .WithMessage("Lütfen şube seçiniz!");
        }
    }
}
