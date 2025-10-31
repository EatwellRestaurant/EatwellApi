using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.Permission;

namespace EatwellApi.Application.Dtos.Permission
{
    public class PermissionListDto : IDto
    {
        public int Id { get; set; }

        public int LeaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public StatusType Status { get; set; }

        public string StatusName { get; set; }
    }
}
