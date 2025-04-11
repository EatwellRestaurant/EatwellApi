using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        readonly IMapper _mapper;

        public MealCategoryManager(
            IMealCategoryDal mealCategoryDal,
            IFileHelper fileHelper,
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(mealCategoryDal)
        {
            _mealCategoryDal = mealCategoryDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [ValidationAspect(typeof(MealCategoryUpsertDtoValidator))]
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


        public async Task<DeleteSuccessResponse> SetDeleteOrRestore(int mealCategoryId)
        {
            MealCategory mealCategory = await GetByIdMealCategoryForDeleteAndUpdate(mealCategoryId);

            mealCategory.IsDeleted = !mealCategory.IsDeleted;
            string responseMessage;

            if (mealCategory.IsDeleted)
            {
                mealCategory.DeleteDate = DateTime.Now;
                responseMessage = CommonMessages.EntityDeleted;
            }
            else
            {
                mealCategory.DeleteDate = null;
                mealCategory.UpdateDate = DateTime.Now;
                responseMessage = CommonMessages.EntityRestored;
            }

            _mealCategoryDal.Update(mealCategory);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(responseMessage);
        }


        public async Task<IDataResult<MealCategory?>> Get(int id)
        {
            return new SuccessDataResult<MealCategory?>(await _mealCategoryDal.GetAsync(m => m.Id == id), MealCategoryMessages.MealCategoryWasBrought);
        }


        public async Task<DataResponse<List<MealCategoryListDto>>> GetAllForAdmin()
            => new DataResponse<List<MealCategoryListDto>>
                (_mapper.Map<List<MealCategoryListDto>>
                (await _mealCategoryDal.GetAllAsync()), 
                CommonMessages.EntityListed);


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






        #region BusinessRules
        
        private async Task<MealCategory> GetByIdMealCategoryForDeleteAndUpdate(int mealCategoryId)
        {
            MealCategory? mealCategory = await _mealCategoryDal
                .Where(m => m.Id == mealCategoryId)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Menü");


            return mealCategory;
        }
        
        #endregion
    }
}
