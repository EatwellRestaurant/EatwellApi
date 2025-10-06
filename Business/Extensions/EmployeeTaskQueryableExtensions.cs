using Entities.Concrete;
using Entities.Enums.EmployeeTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class EmployeeTaskQueryableExtensions
    {
        public static IQueryable<EmployeeTask> FilterByEmployeeId(this IQueryable<EmployeeTask> query, int employeeId)
            => query.Where(e => e.AssigneeId == employeeId);
        
        
        
        public static IQueryable<EmployeeTask> FilterByPriorityLevel(this IQueryable<EmployeeTask> query, PriorityLevelEnum? priorityLevel)
            => query.Where(e => !priorityLevel.HasValue || e.PriorityLevel == priorityLevel);
         
        

        public static IQueryable<EmployeeTask> FilterByTaskStatus(this IQueryable<EmployeeTask> query, TaskStatusEnum? taskStatus)
            => query.Where(e => !taskStatus.HasValue || e.TaskStatus == taskStatus);
        
    }
}
