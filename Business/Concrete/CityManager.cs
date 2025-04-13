using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.City;
using Entities.Dtos.Country;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<DataResponse<CityWithBranchesDto>> Get(int cityId)
        {
            City city = await _cityDal
                .Where(c => c.Id == cityId)
                .Include(c => c.Branches)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şehir");


            return new DataResponse<CityWithBranchesDto>(_mapper.Map<CityWithBranchesDto>(city), CommonMessages.EntityFetch);
        }


        public async Task<DataResponse<List<CityWithBranchCountDto>>> GetAll()
            => new DataResponse<List<CityWithBranchCountDto>>(_mapper.Map<List<CityWithBranchCountDto>>
                (await _cityDal
                .GetAllQueryable()
                .Include(c => c.Branches)
                .ToListAsync()),
                CommonMessages.EntityListed);

    }
}
