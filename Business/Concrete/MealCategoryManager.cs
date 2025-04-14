using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

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


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(MealCategoryUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(MealCategoryUpsertDto upsertDto)
        {
            MealCategory mealCategory = new()
            {
                Name = upsertDto.Name,
                ImagePath = _fileHelper.Upload(upsertDto.Image).Data
            };

            await _mealCategoryDal.AddAsync(mealCategory);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }



        [SecuredOperation("admin")]
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



        [SecuredOperation("admin")]
        public async Task<DataResponse<MealCategoryDetailDto>> GetForAdmin(int mealCategoryId)
        {
            MealCategory? mealCategory = await _mealCategoryDal
                .GetAsNoTrackingAsync(m => m.Id == mealCategoryId)
                ?? throw new EntityNotFoundException("Menü");

            return new DataResponse<MealCategoryDetailDto>
                (_mapper.Map<MealCategoryDetailDto>(mealCategory), 
                CommonMessages.EntityFetch);
        }



        [SecuredOperation("admin")]
        public async Task<DataResponse<List<MealCategoryListDto>>> GetAllForAdmin()
            => new DataResponse<List<MealCategoryListDto>>(_mapper.Map<List<MealCategoryListDto>>
                (await _mealCategoryDal
                .GetAllQueryable()
                .OrderByDescending(m => m.CreateDate)
                .ToListAsync()), 
                CommonMessages.EntityListed);



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(MealCategoryUpsertDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Update(int mealCategoryId, MealCategoryUpsertDto upsertDto)
        {
            MealCategory mealCategory = await GetByIdMealCategoryForDeleteAndUpdate(mealCategoryId);

            mealCategory.UpdateDate = DateTime.Now;
            mealCategory.Name = upsertDto.Name;
            mealCategory.ImagePath = _fileHelper.Update(upsertDto.Image, mealCategory.ImagePath).Data;

            _mealCategoryDal.Update(mealCategory);
            await _unitOfWork.SaveChangesAsync();
            
            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
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
