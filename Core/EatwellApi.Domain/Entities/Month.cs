using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class Month : BaseEntity
    {
        public int YearId { get; set; }

        public string Name { get; set; }





        public Year Year { get; set; }
        public ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public ICollection<EmployeeBonus> EmployeeBonuses { get; set; }
        public ICollection<EmployeeDeduction> EmployeeDeductions { get; set; }
    }
}
