using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Extensions
{
    public static class EmployeeQueryableExtensions
    {
        public static IQueryable<Employee> FilterByBranchId(this IQueryable<Employee> query, int? branchId)
            => query.Where(e => !branchId.HasValue || e.BranchId == branchId);


        public static IQueryable<Employee> FilterByUserId(this IQueryable<Employee> query, int? userId)
            => query.Where(e => !userId.HasValue || e.UserId != userId);


        public static IQueryable<Employee> FilterByWorkStatus(this IQueryable<Employee> query, WorkStatusType? workStatus)
            => query.Where(e => !workStatus.HasValue || e.WorkStatus == workStatus);


        public static IQueryable<Employee> FilterByOperationClaimId(this IQueryable<Employee> query, int? operationClaimId)
            => query.Where(e => !operationClaimId.HasValue || e.User.OperationClaimId == operationClaimId);


        public static IQueryable<Employee> FilterByFullName(this IQueryable<Employee> query, string? fullName)
            => query.Where(e => fullName == null || e.User.FirstName.Contains(fullName) || e.User.LastName.Contains(fullName));
    }
}
