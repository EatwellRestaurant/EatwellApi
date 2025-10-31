using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.EmployeeTask;

namespace EatwellApi.Application.Dtos.EmployeeTask
{
    public class EmployeeTaskFilterRequestDto : IDto
    {
        public PriorityLevelEnum? PriorityLevel { get; set; }

        public TaskStatusEnum? TaskStatus { get; set; }
    }
}
