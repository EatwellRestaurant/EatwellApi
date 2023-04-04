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

        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(CityMessages.CityAdded);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(CityMessages.CityDeleted);
        }

        public IDataResult<City> Get(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id), CityMessages.CityWasBrought);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), CityMessages.CitiesListed);
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(CityMessages.CityUpdated);
        }
    }
}
