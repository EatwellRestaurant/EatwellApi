using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
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
        readonly IFileHelper _fileHelper;

        public MealCategoryManager(IMealCategoryDal mealCategoryDal, IFileHelper fileHelper)
        {
            _mealCategoryDal = mealCategoryDal;
            _fileHelper = fileHelper;
        }

        public async Task<IResult> Add(MealCategoryUpsertDto upsertDto)
        {
            var resim = _fileHelper.Upload(upsertDto.Image).Data;
            MealCategory mealCategory = new()
            {
                Name = upsertDto.Name,
                ImagePath = resim
            };

            await _mealCategoryDal.AddAsync(mealCategory);
         
            return new SuccessResult(MealCategoryMessages.MealCategoryAdded);
        }

        public IResult Delete(MealCategory mealCategory)
        {
            _mealCategoryDal.Remove(mealCategory);
            return new SuccessResult(MealCategoryMessages.MealCategoryDeleted);
        }

        public async Task<IDataResult<MealCategory?>> Get(int id)
        {
            return new SuccessDataResult<MealCategory?>(await _mealCategoryDal.GetAsync(m => m.Id == id), MealCategoryMessages.MealCategoryWasBrought);
        }

        public async Task<IDataResult<List<MealCategory>>> GetAll()
        {
            return new SuccessDataResult<List<MealCategory>>(await _mealCategoryDal.GetAllAsync(), MealCategoryMessages.MealCategoriesListed);
        }

        public IResult Update(IFormFile file, MealCategory mealCategory)
        {
            var result = _fileHelper.Update(file, mealCategory.ImagePath, ImagePaths.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            mealCategory.ImagePath = result.Data;

            _mealCategoryDal.Update(mealCategory);
            return new SuccessResult(MealCategoryMessages.MealCategoryUpdated);
        }
    }
}
