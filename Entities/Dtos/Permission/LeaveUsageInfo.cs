using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Permission
{
    public class LeaveUsageInfo : IDto
    {
        public double UsedLeaveDays { get; set; }
        public int ExperienceInYears { get; set; }
    }
}
