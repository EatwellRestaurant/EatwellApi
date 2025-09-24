using Core.Entities.Abstract;
using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeBonus
{
    public class EmployeeBonusListDto : IDto
    {
        public int Id { get; set; }

        public string BonusType { get; set; }
         
        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }
        
        public string PaymentStatusName { get; set; }
    }
}
