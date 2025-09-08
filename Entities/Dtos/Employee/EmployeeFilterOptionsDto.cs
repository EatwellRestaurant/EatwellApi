using Core.Entities.Abstract;
using Entities.Dtos.Branch;
using Entities.Dtos.OperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeFilterOptionsDto : IDto
    {
        public List<WorkStatusDto> WorkStatusDtos { get; set; }

        public List<OperationClaimListDto> OperationClaimListDtos { get; set; }

        public List<BaseBranchDto> BranchDtos { get; set; }

    }
}
