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
    public class YearManager : IYearService
    {
        readonly IYearDal _yearDal;

        public YearManager(IYearDal yearDal)
        {
            _yearDal = yearDal;
        }



        public async Task CheckIfYearIdExists(int yearId)
        {
            if(!await _yearDal.AnyAsync(y => y.Id == yearId && !y.IsDeleted))
                throw new EntityNotFoundException("Yıl");
        }
    }
}
