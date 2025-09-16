using Business.Abstract;
using Core.Exceptions.General;
using Core.Exceptions.ShiftDay;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ShiftDay;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShiftDayManager : Manager<ShiftDay>, IShiftDayService
    {
        readonly IShiftDayDal _shiftDayDal;

        public ShiftDayManager(IShiftDayDal shiftDayDal) : base(shiftDayDal)
        {
            _shiftDayDal = shiftDayDal;
        }


        public void ValidateShiftDays(HashSet<ShiftDayDto> shiftDayDtos)
        {
            Dictionary<int, string> dayNames = new()
            {
                {1, "Pazartesi"},
                {2, "Salı"},
                {3, "Çarşamba"},
                {4, "Perşembe"},
                {5, "Cuma"},
                {6, "Cumartesi"},
                {7, "Pazar"}
            };


            IEnumerable<int> expectedIds = Enumerable.Range(1, 7);
            IEnumerable<int> missingIds = expectedIds.Except(shiftDayDtos.Select(sd => sd.ShiftId));

            var missingDays = missingIds.Select(id => dayNames[id]);


            if (missingDays.Any())
            {
                throw new IncompleteShiftScheduleException(string.Join(", ", missingDays));
            }
        }
    }
}
