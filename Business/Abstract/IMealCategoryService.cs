using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealCategoryService
    {
        IDataResult<List<MealCategory>> GetAll();
        IDataResult<MealCategory> Get(int id);
        IResult Add(MealCategory mealCategory);
        IResult Update(MealCategory mealCategory);
        IResult Delete(MealCategory mealCategory);
    }
}
