using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Exceptions.General;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Dtos.Year;
using Entities.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;

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

        


        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<List<YearListDto>>> GetAllAsync()
        {
            List<YearListDto> yearListDtos = await _yearDal
                .Where(y => !y.IsDeleted)
                .AsNoTracking()
                .Select(y => new YearListDto()
                {
                    Id = y.Id,
                    Name = y.Name,
                })
                .ToListAsync();


            return new DataResponse<List<YearListDto>>(
                yearListDtos
                .OrderByDescending(y => int.Parse(y.Name))
                .ToList(), 
                CommonMessages.EntityListed);
        }


    }
}
