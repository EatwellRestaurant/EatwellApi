using Core.Entities.Abstract;
using Entities.Dtos.EmployeeBonus;
using Entities.Dtos.EmployeeDeduction;
using Entities.Enums.Employee;

namespace Entities.Dtos.Employee
{
    public class EmployeeFinancialListDto : IDto
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal NetSalary { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }

        public string PaymentStatusName { get; set; }

        public decimal? MealAllowance { get; set; }

        public decimal? TransportAllowance { get; set; }

        public decimal? EducationAllowance { get; set; }

        public decimal? AdditionalPayments { get; set; }

        public decimal? Bonuses { get; set; }

        public decimal? Deductions { get; set; }

        public List<EmployeeDeductionListDto> EmployeeDeductionListDtos { get; set; }

        public List<EmployeeBonusListDto> EmployeeBonusListDtos { get; set; }
    }
}
