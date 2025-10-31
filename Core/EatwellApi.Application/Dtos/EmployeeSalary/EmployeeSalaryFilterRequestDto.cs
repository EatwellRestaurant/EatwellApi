using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Dtos.EmployeeSalary
{
    public class EmployeeSalaryFilterRequestDto : IDto
    {
        public int? YearId { get; set; }

        public PaymentStatusEnum? PaymentStatus { get; set; }
    }
}
