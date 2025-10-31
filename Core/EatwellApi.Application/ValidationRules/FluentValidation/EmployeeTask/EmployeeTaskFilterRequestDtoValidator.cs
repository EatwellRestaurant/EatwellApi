using EatwellApi.Application.Dtos.EmployeeTask;
using EatwellApi.Domain.Enums.EmployeeTask;
using FluentValidation;

namespace EatwellApi.Application.ValidationRules.FluentValidation.EmployeeTask
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
