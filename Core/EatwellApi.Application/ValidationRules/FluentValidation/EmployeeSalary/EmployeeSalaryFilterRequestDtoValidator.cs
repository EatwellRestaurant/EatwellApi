using EatwellApi.Application.Dtos.EmployeeSalary;
using EatwellApi.Domain.Enums.Employee;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.EmployeeSalary
{
    public class EmployeeSalaryFilterRequestDtoValidator : AbstractValidator<EmployeeSalaryFilterRequestDto>
    {
        public EmployeeSalaryFilterRequestDtoValidator()
        {
            RuleFor(e => e.PaymentStatus)
                .Must(e => Enum.IsDefined(typeof(PaymentStatusEnum), e))
                .When(e => e.PaymentStatus.HasValue)
                .WithMessage("Geçerli bir ödeme türü seçiniz!");
        }
    }
}
