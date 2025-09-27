using Core.Entities.Abstract;
using Core.Requests;
using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeSalary
{
    public class EmployeeSalaryFilterRequestDto : IDto
    {
        public int? YearId { get; set; }

        public PaymentStatusEnum? PaymentStatus { get; set; }
    }
}
