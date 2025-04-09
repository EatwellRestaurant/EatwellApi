using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<IResult> Add(Country country)
        {
            await _countryDal.AddAsync(country);
            return new SuccessResult(CountryMessages.CountryAdded);
        }

        public IResult Delete(Country country)
        {
            _countryDal.Remove(country);
            return new SuccessResult(CountryMessages.CountryDeleted);
        }

        public async Task<IDataResult<Country?>> Get(int id)
        {
            return new SuccessDataResult<Country?>(await _countryDal.GetAsync(c => c.Id == id), CountryMessages.CountryWasBrought);
        }

        public async Task<IDataResult<List<Country>>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(await _countryDal.GetAllAsync(), CountryMessages.CountriesListed);
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(CountryMessages.CountryUpdated);
        }
    }
}
