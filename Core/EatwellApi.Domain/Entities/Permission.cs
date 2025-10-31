using EatwellApi.Domain.Entities.Common;
using EatwellApi.Domain.Enums.Permission;

namespace EatwellApi.Domain.Entities
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
