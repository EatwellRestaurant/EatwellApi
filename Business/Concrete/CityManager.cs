using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Exceptions.General;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.City;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class CityManager : Manager<City>, ICityService
    {
        readonly ICityDal _cityDal;
        readonly IMapper _mapper;

        public CityManager(ICityDal cityDal, IMapper mapper) : base(cityDal) 
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }



        public async Task<DataResponse<List<CityWithBranchCountDto>>> GetAll()
            => new DataResponse<List<CityWithBranchCountDto>>(_mapper.Map<List<CityWithBranchCountDto>>
                (await _cityDal
                .GetAllQueryable()
                .Include(c => c.Branches.Where(b => !b.IsDeleted))
                .AsNoTracking()
                .ToListAsync()),
                CommonMessages.EntityListed);

    }
}
