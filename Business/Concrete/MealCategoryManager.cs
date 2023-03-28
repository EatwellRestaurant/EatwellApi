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
    public class MealCategoryManager : IMealCategoryService
    {
        private IMealCategoryDal _mealCategoryDal;

        public MealCategoryManager(IMealCategoryDal mealCategoryDal)
        {
            _mealCategoryDal = mealCategoryDal;
        }

        public IResult Add(MealCategory mealCategory)
        {
            _mealCategoryDal.Add(mealCategory);
            return new SuccessResult(MealCategoryMessages.MealCategoryAdded);
        }

        public IResult Delete(MealCategory mealCategory)
        {
            _mealCategoryDal.Delete(mealCategory);
            return new SuccessResult(MealCategoryMessages.MealCategoryDeleted);
        }

        public IDataResult<MealCategory> Get(int id)
        {
            return new SuccessDataResult<MealCategory>(_mealCategoryDal.Get(m => m.Id == id), MealCategoryMessages.MealCategoryWasBrought);
        }

        public IDataResult<List<MealCategory>> GetAll()
        {
            return new SuccessDataResult<List<MealCategory>>(_mealCategoryDal.GetAll(), MealCategoryMessages.MealCategoriesListed);
        }

        public IResult Update(MealCategory mealCategory)
        {
            _mealCategoryDal.Update(mealCategory);
            return new SuccessResult(MealCategoryMessages.MealCategoryUpdated);
        }
    }
}
