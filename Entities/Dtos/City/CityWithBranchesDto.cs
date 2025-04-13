using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Branch;

namespace Entities.Dtos.City
{
    public class CityWithBranchesDto : CityDto
    {
        public List<BranchDto> Branches { get; set; }
    }
} 
