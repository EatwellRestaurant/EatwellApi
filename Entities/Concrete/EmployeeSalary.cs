using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeSalary : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int MonthId { get; set; }

        public decimal BaseSalary { get; set; }
        
        public decimal GrossSalary { get; set; }
        
        public decimal? MealAllowance { get; set; }

        public decimal? TransportAllowance { get; set; }

        public decimal? EducationAllowance { get; set; }





        public Employee Employee { get; set; }
        public Month Month { get; set; }

    }
}
