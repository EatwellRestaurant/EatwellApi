using Business.Abstract;
using Core.Exceptions.General;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LeaveRightManager : ILeaveRightService
    {
        readonly ILeaveRightDal _leaveRightDal;

        public LeaveRightManager(ILeaveRightDal leaveRightDal)
        {
            _leaveRightDal = leaveRightDal;
        }



        public async Task<LeaveRight> GetLeaveRightByTypeAsync(int leaveTypeId, int yearId, int experienceInYears)
        {
            List<LeaveRight> leaveRights = await _leaveRightDal
                .GetAllAsync(l => l.LeaveTypeId == leaveTypeId && l.YearId == yearId);


            if (leaveRights.Count <= 0)
                throw new EntityNotFoundException("Belirtilen izin türüne göre izin hakkı");


            if (leaveTypeId == (int)LeaveTypeEnum.AnnualLeave)
            {
                return leaveRights
                    .First(l =>
                    {
                        if (l.SeniorityRange.Contains('-'))
                        {
                            // Eğer SeniorityRange sütununun min-max değerleri varsa...
                            var parts = l.SeniorityRange.Split('-');
                            int min = int.Parse(parts[0]);
                            int max = int.Parse(parts[1]);
                            
                            return experienceInYears >= min && experienceInYears <= max;
                        }
                        else
                        {
                            // SeniorityRange sütununun tek bir değeri varsa...
                            int singleValue = int.Parse(l.SeniorityRange);

                            return experienceInYears >= singleValue;
                        }
                    });
            }
            
            
            return leaveRights.First();
        }

    }
}
