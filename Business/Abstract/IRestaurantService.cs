using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRestaurantService
    {
        IDataResult<List<Restaurant>> GetAll();
        IDataResult<Restaurant> Get(int id);
        IResult Add(Restaurant restaurant);
        IResult Delete(Restaurant restaurant);
        IResult Update(Restaurant restaurant);
    }
}
