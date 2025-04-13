using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Core.Exceptions.Country;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        readonly ICountryDal _countryDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public CountryManager(ICountryDal countryDal, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _countryDal = countryDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<DataResponse<CountryDto>> Get(int countryId)
        {
            Country country = await _countryDal
                .Where(c => c.Id == countryId && c.IsActive)
                .Include(c => c.Cities)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Ülke");


            return new DataResponse<CountryDto>(_mapper.Map<CountryDto>(country), CommonMessages.EntityFetch);
        }
        
        
        public async Task<DataResponse<CountryDto>> GetForAdmin(int countryId)
        {
            Country country = await _countryDal
                .Where(c => c.Id == countryId)
                .Include(c => c.Cities)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Ülke");


            return new DataResponse<CountryDto>(_mapper.Map<CountryDto>(country), CommonMessages.EntityFetch);
        }



        public async Task<DataResponse<List<AdminCountryListDto>>> GetAllForAdmin() 
            => new DataResponse<List<AdminCountryListDto>>(_mapper.Map<List<AdminCountryListDto>>
                (await _countryDal
                .GetAllAsync()), 
                CommonMessages.EntityListed);
        
        
        
        public async Task<DataResponse<List<CountryDto>>> GetAll() 
            => new DataResponse<List<CountryDto>>(_mapper.Map<List<CountryDto>>
                (await _countryDal
                .GetAllAsync(c => c.IsActive)), 
                CommonMessages.EntityListed);



        public async Task<SuccessResponse> SetActive(ActivateCountryIdsDto countryIdsDto)
        {
            List<Country> countries = await _countryDal
                .GetAllList();


            List<int> activeCountryIds = countryIdsDto.Ids;

            List<int> unavailableCountryIds = activeCountryIds.Except(countries.Select(c => c.Id)).ToList();

            if (unavailableCountryIds.Any())
                throw new EntitiesNotFoundException("ülkeler") 
                { 
                    Ids = unavailableCountryIds 
                };


            List<Country> activeCountries = countries.Where(c => activeCountryIds.Contains(c.Id)).ToList();
            
            activeCountries.ForEach(a => a.IsActive = true);


            List<Country> passiveCountries = countries.Where(c => !activeCountryIds.Contains(c.Id)).ToList();

            if (passiveCountries.Any(p => p.Id == 1))
                throw new TurkeyPassiveNotAllowedException();

            passiveCountries.ForEach (a => a.IsActive = false);


            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse(CountryMessages.CountryStatusUpdated, StatusCodes.Status200OK);
        }




    }
}
