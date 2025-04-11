using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MealCategoryManager : Manager<MealCategory>, IMealCategoryService
    {
        readonly IMealCategoryDal _mealCategoryDal;
        readonly IFileHelper _fileHelper;
        readonly IUnitOfWork _unitOfWork;

        public MealCategoryManager(
            IMealCategoryDal mealCategoryDal, 
            IFileHelper fileHelper, 
            IUnitOfWork unitOfWork)
            : base(mealCategoryDal)
        {
            _mealCategoryDal = mealCategoryDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateSuccessResponse> Add(MealCategoryUpsertDto upsertDto)
        {
            MealCategory mealCategory = new()
            {
                Name = upsertDto.Name,
                ImagePath = _fileHelper.Upload(upsertDto.Image).Data
            };

            await _mealCategoryDal.AddAsync(mealCategory);
            await _unitOfWork.SaveChangesAsync();
         
            return new CreateSuccessResponse(MealCategoryMessages.MealCategoryAdded);
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
