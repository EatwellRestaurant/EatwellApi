using Entities.Dtos.EmployeeTask;
using Entities.Enums.Employee;
using Entities.Enums.EmployeeTask;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.EmployeeTask
{
    public class EmployeeTaskFilterRequestDtoValidator : AbstractValidator<EmployeeTaskFilterRequestDto>
    {
        public EmployeeTaskFilterRequestDtoValidator()
        {
            RuleFor(e => e.PriorityLevel)
               .Must(e => Enum.IsDefined(typeof(PriorityLevelEnum), e))
               .When(e => e.PriorityLevel.HasValue)
               .WithMessage("Geçerli bir öncelik türü seçiniz!");
            
            
            
            RuleFor(e => e.TaskStatus)
               .Must(e => Enum.IsDefined(typeof(TaskStatusEnum), e))
               .When(e => e.TaskStatus.HasValue)
               .WithMessage("Geçerli bir görev durumu seçiniz!");
        }
    }
}
