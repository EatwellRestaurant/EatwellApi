using Entities.Dtos.EmployeeSalary;
using Entities.Enums.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.EmployeeSalary
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
