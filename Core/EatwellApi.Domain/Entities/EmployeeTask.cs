using EatwellApi.Domain.Entities.Common;
using EatwellApi.Domain.Enums.EmployeeTask;

namespace EatwellApi.Domain.Entities
{
    public class EmployeeTask : BaseEntity
    {
        /// <summary>
        /// Görevi atadığımız çalışan
        /// </summary>
        public int AssigneeId { get; set; }

        /// <summary>
        /// Görevi atayan kişi
        /// </summary>
        public int AssignedById { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public PriorityLevelEnum PriorityLevel { get; set; }

        public TaskStatusEnum TaskStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }






        public Employee Assignee { get; set; }
        public Employee AssignedBy { get; set; }
        public ICollection<EmployeeTaskComment> EmployeeTaskComments { get; set; }
        public ICollection<EmployeeSubTask> EmployeeSubTasks { get; set; }
    }
}
