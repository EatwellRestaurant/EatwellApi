using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class BranchSalesDto
    {
        public int Id { get; set; }     
        
        public string Name { get; set; }        
        
        public List<MonthlySalesDto> Sales { get; set; }
    }
}
