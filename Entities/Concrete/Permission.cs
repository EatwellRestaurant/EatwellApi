using Entities.Enums;
using Entities.Enums.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Permission : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int YearId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public StatusType Status { get; set; }





        public Employee Employee { get; set; }
        public Year Year { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
