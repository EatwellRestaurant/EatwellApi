using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Permission
{
    public class PermissionUpsertDto : IDto
    {
        public int? EmployeeId { get; set; }

        public int YearId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}
