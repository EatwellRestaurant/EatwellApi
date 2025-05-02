using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class BranchInsertDto : BranchUpdateDto
    {
        public int CityId { get; set; }
    }
}
