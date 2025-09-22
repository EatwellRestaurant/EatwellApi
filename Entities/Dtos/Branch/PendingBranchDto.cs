using Core.Entities.Abstract;
using Entities.Enums.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class PendingBranchDto : BaseBranchDto
    {
        public BranchStatusEnum Status { get; set; }

        public string StatusName { get; set; }

        public DateTime? EstimatedOpeningDate { get; set; } 
    }
}
  