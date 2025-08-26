using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum BranchStatusEnum : byte
    {
        Opened = 1,
        AwaitingApproval = 2,
        Planning = 3,
        Installation = 4,
    }
}
