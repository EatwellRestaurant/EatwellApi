using Business.Abstract;
using Core.Exceptions.General;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LeaveTypeManager : ILeaveTypeService
    {
        readonly ILeaveTypeDal _leaveTypeDal;

        public LeaveTypeManager(ILeaveTypeDal leaveTypeDal)
        {
            _leaveTypeDal = leaveTypeDal;
        }



        public async Task CheckIfLeaveTypeIdExists(int leaveTypeId)
        {
            if (!await _leaveTypeDal.AnyAsync(l => l.Id == leaveTypeId))
                throw new EntityNotFoundException("İzin türü");
        }
    }
}
