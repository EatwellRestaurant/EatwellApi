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

        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult(CountryMessages.CountryAdded);
        }

        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(CountryMessages.CountryDeleted);
        }

        public IDataResult<Country> Get(int id)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(c => c.Id == id), CountryMessages.CountryWasBrought);
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll(), CountryMessages.CountriesListed);
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(CountryMessages.CountryUpdated);
        }
    }
}
