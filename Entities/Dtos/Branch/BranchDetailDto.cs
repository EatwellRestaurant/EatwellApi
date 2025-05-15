using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class BranchDetailDto : BranchListDto
    {
        public string CityName { get; set; }
        
        public string Phone { get; set; }
        
        public string? WebSite { get; set; }
        
        public string? Facebook { get; set; }
        
        public string? Instagram { get; set; }
        
        public string? Twitter { get; set; }
        
        public string? Gmail { get; set; }

    }
}
