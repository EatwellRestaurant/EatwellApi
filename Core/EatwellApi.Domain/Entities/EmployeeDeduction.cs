using EatwellApi.Domain.Entities.Common;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Domain.Entities
{
    public class EmployeeDeduction : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int MonthId { get; set; }

        public DeductionType DeductionType { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }





        public Employee Employee { get; set; }
        public Month Month { get; set; }

    }
}
