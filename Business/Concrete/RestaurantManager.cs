using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class RestaurantManager : IRestaurantService
    {
        private IRestaurantDal _restaurantDal;

        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }

        
        [ValidationAspect(typeof(RestaurantValidator))]
        public IResult Add(Restaurant restaurant)
        {
            _restaurantDal.Add(restaurant);
            return new SuccessResult(RestaurantMessages.RestaurantAdded);
        }

        public IResult Delete(Restaurant restaurant)
        {
            _restaurantDal.Delete(restaurant);
            return new SuccessResult(RestaurantMessages.RestaurantDeleted);
        }

        public IDataResult<Restaurant> Get(int id)
        {
            return new SuccessDataResult<Restaurant>(_restaurantDal.Get(r => r.Id == id), RestaurantMessages.RestaurantWasBrought);
        }

        public IDataResult<List<Restaurant>> GetAll()
        {
            return new SuccessDataResult<List<Restaurant>>(_restaurantDal.GetAll(), RestaurantMessages.RestaurantsListed);
        }


        [ValidationAspect(typeof(RestaurantValidator))]
        public IResult Update(Restaurant restaurant)
        {
            _restaurantDal.Update(restaurant);
            return new SuccessResult(RestaurantMessages.RestaurantUpdated);
        }
    }
}
