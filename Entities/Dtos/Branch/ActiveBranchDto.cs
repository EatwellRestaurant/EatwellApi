using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class ActiveBranchDto : IDto
    {
        public List<SalesBranchDto> SalesBranchDtos { get; set; }

        public List<NonSalesBranchDto> NonSalesBranchDtos { get; set; }

    }
}
