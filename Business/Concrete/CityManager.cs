using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Exceptions.General;
using Core.Extensions;
using Core.Requests;
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



        public async Task<object> GetAll(PaginationRequest? paginationRequest)
        {
            IQueryable<City> query = _cityDal
                .GetAllQueryable();

            List<CityWithBranchCountDto> cityLists = _mapper.Map<List<CityWithBranchCountDto>>
                (await query
                .Include(c => c.Branches.Where(b => !b.IsDeleted))
                .ApplyPagination(paginationRequest)
                .ToListAsync());

            return paginationRequest != null 
                ? new PaginationResponse<CityWithBranchCountDto>(cityLists, paginationRequest, await query.CountAsync())
                : new DataResponse<List<CityWithBranchCountDto>>(cityLists, CommonMessages.EntityListed);
        }

    }
}
