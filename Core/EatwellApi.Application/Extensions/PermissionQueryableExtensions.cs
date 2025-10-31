using EatwellApi.Domain.Entities;

namespace EatwellApi.Application.Extensions
{
    public static class PermissionQueryableExtensions
    {
        public static IQueryable<Permission> FilterByEmployeeId(this IQueryable<Permission> query, int employeeId)
            => query.Where(p => p.EmployeeId == employeeId);


        public static IQueryable<Permission> FilterByYearId(this IQueryable<Permission> query, int yearId)
            => query.Where(p => p.YearId == yearId);


        public static IQueryable<Permission> FilterByLeaveTypeId(this IQueryable<Permission> query, int? leaveTypeId)
            => query.Where(p => !leaveTypeId.HasValue || p.LeaveTypeId == leaveTypeId);
    }
}
