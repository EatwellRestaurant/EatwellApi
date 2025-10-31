using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Permission
{
    public class PermissionFilterRequestDto : IDto
    {
        public int? YearId { get; set; }

        public int? LeaveTypeId { get; set; }
    }
}
