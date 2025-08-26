using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class BranchOverviewDto : IDto
    { 
        public List<ActiveBranchDto> ActiveBranchDtos { get; set; }

        public List<PendingBranchDto> PendingBranchDtos { get; set; }

    } 
}
