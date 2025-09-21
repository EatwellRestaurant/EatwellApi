using Core.Entities.Abstract;
using Entities.Enums.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Permission
{
    public class PermissionUpsertDto : IDto
    {
        public int EmployeeId { get; set; }

        public int YearId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}
