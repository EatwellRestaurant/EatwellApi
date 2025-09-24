using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeSalary
{
    public class EmployeeSalaryListDto : IDto
    {
        public int Id { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal NetSalary { get; set; } 

        public decimal? MealAllowance { get; set; }

        public decimal? TransportAllowance { get; set; }

        public decimal? EducationAllowance { get; set; }
    }
}
