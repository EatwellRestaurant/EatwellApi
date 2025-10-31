using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Dtos.EmployeeBonus
{
    public class EmployeeBonusListDto : IDto
    {
        public int Id { get; set; }

        public BonusType BonusType { get; set; }

        public string BonusTypeName { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }

        public string PaymentStatusName { get; set; }
    }
}
