using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationClaim
{
    public class OperationClaimListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
