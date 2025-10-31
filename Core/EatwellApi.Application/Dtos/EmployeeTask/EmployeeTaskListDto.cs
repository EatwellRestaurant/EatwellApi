using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.EmployeeTask;

namespace EatwellApi.Application.Dtos.EmployeeTask
{
    public class EmployeeTaskListDto : IDto
    {
        public int Id { get; set; }

        public string AssignedByFullName { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public PriorityLevelEnum PriorityLevel { get; set; }

        public string PriorityLevelName { get; set; }

        public TaskStatusEnum TaskStatus { get; set; }

        public string TaskStatusName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte ProgressPercentage { get; set; }

    }
}
