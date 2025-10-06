using Core.Entities.Abstract;
using Entities.Enums.EmployeeTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeTask
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
