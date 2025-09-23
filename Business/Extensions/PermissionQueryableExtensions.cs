using Entities.Concrete;
using Entities.Enums.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class PermissionQueryableExtensions 
    {
        public static IQueryable<Permission> FilterByEmployeeId(this IQueryable<Permission> query, int employeeId)
            => query.Where(p  => p.EmployeeId == employeeId);
        
        
        public static IQueryable<Permission> FilterByYearId(this IQueryable<Permission> query, int yearId)
            => query.Where(p  => p.YearId == yearId);
        
        
        public static IQueryable<Permission> FilterByLeaveTypeId(this IQueryable<Permission> query, int? leaveTypeId)
            => query.Where(p  => !leaveTypeId.HasValue || p.LeaveTypeId == leaveTypeId);
    } 
}
