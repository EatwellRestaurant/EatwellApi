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
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<IResult> Add(City city)
        {
            await _cityDal.AddAsync(city);
            return new SuccessResult(CityMessages.CityAdded);
        }

        public IResult Delete(City city)
        {
            _cityDal.Remove(city);
            return new SuccessResult(CityMessages.CityDeleted);
        }

        public async Task<IDataResult<City?>> Get(int id)
        {
            return new SuccessDataResult<City?>(await _cityDal.GetAsync(c => c.Id == id), CityMessages.CityWasBrought);
        }

        public async Task<IDataResult<List<City>>> GetAll()
        {
            return new SuccessDataResult<List<City>>(await _cityDal.GetAllAsync(), CityMessages.CitiesListed);
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(CityMessages.CityUpdated);
        }
    }
}
