using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeTask
{
    public class EmployeeTaskFilterOptionsDto : IDto
    {
        public List<PriorityLevelDto> PriorityLevelDtos { get; set; }

        public List<TaskStatusDto> TaskStatusDtos { get; set; }
    }
}
