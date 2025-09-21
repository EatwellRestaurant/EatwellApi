using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILeaveRightService
    {
        Task<LeaveRight> GetLeaveRightByTypeAsync(int leaveTypeId, int yearId, int experienceInYears);
    }
}
