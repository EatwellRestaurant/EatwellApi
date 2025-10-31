using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Dtos.EmployeeDeduction
{
    public class EmployeeDeductionListDto : IDto
    {
        public int Id { get; set; }

        public DeductionType DeductionType { get; set; }

        public string DeductionTypeName { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }

        public string PaymentStatusName { get; set; }
    }
}
