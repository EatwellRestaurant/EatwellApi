using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Extensions
{
    public static class EmployeeSalaryQueryableExtensions
    {
        public static IQueryable<EmployeeSalary> FilterByEmployeeId(this IQueryable<EmployeeSalary> query, int employeeId)
            => query.Where(p => p.EmployeeId == employeeId);


        public static IQueryable<EmployeeSalary> FilterByYearId(this IQueryable<EmployeeSalary> query, int? yearId)
            => query.Where(p => !yearId.HasValue || p.Month.YearId == yearId);


        public static IQueryable<EmployeeSalary> FilterByPaymentStatus(this IQueryable<EmployeeSalary> query, PaymentStatusEnum? paymentStatus)
            => query.Where(p => !paymentStatus.HasValue || p.PaymentStatus == paymentStatus);
    }
}
