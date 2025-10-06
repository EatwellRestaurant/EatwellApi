using Core.Entities.Abstract;
using Entities.Enums.EmployeeTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeTask
{
    public class EmployeeTaskFilterRequestDto : IDto
    {
        public PriorityLevelEnum? PriorityLevel { get; set; }

        public TaskStatusEnum? TaskStatus { get; set; }
    }
}
