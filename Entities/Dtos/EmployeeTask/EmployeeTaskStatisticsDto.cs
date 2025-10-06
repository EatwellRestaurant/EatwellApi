using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeTask
{
    public class EmployeeTaskStatisticsDto
    {
        public int TotalTaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public int InProgressTaskCount { get; set; }

        public int PendingTaskCount { get; set; }
    }

}
