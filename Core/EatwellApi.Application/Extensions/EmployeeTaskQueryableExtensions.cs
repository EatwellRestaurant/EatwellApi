using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Enums.EmployeeTask;

namespace EatwellApi.Application.Extensions
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
