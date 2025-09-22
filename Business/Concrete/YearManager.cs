using Business.Abstract;
using Core.Exceptions.General;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
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



        public async Task<string> CheckIfYearIdExists(int yearId)
        {
            string? year =  await _yearDal
                .Where(y => y.Id == yearId && !y.IsDeleted)
                .AsNoTracking()
                .Select(y => y.Name)
                .SingleOrDefaultAsync();

            if(year == null)
                throw new EntityNotFoundException("Yıl"); 

            return year;
        }




        public async Task<int> GetCurrentYearIdAsync()
        {
            string year = DateTime.Now.Year.ToString();

            int? yearId = await _yearDal
                .Where(y => y.Name == year && !y.IsDeleted)
                .AsNoTracking()
                .Select(y => y.Id)
                .SingleOrDefaultAsync();

            return yearId.Value;
        }
    }
}
