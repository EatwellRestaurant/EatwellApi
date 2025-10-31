using EatwellApi.Application.Dtos.Employee;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.Employee
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
