using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeSubTask : BaseEntity
    {
        public int EmployeeTaskId { get; set; }

        public string Name { get; set; }

        public DateTime? CompletedDate { get; set; }




         
        public EmployeeTask EmployeeTask { get; set; }
    }
}
