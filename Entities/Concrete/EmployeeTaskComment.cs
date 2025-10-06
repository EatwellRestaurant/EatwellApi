using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeTaskComment : BaseEntity
    {
        public int EmployeeId { get; set; }
        
        public int EmployeeTaskId { get; set; }

        public string Comment { get; set; }





        public Employee Employee { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
