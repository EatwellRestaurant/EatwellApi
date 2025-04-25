using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.File;
using Core.Exceptions.General;
using Core.Exceptions.MealCategory;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
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
            await CheckIfMealCategoryNameExists(upsertDto.Name);

            CheckIfFileEnter(upsertDto.Image);

            ImageRespone imageRespone = await _fileHelper.Upload(upsertDto.Image!);

            MealCategory mealCategory = new()
            {
                Name = upsertDto.Name,
                ImagePath = imageRespone.Path,
                ImageName = imageRespone.Name,
            };

            await _mealCategoryDal.AddAsync(mealCategory);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }



        [SecuredOperation("admin")]
        public async Task<DeleteSuccessResponse> SetDeleteOrRestore(int mealCategoryId)
        {
            MealCategory mealCategory = await GetByIdMealCategoryForDeleteAndUpdate(mealCategoryId);

            string responseMessage;

            if (mealCategory.IsDeleted)
            {
                if (await _mealCategoryDal.Where(m => m.Name == mealCategory.Name && m.Id != mealCategoryId && !m.IsDeleted).AnyAsync())
                    throw new CannotActivateMealCategoryException();

                mealCategory.DeleteDate = null;
                mealCategory.UpdateDate = DateTime.Now;
                responseMessage = MealCategoryMessages.MealCategoryActivated;
            }
            else
            {
                mealCategory.DeleteDate = DateTime.Now;
                responseMessage = MealCategoryMessages.MealCategoryDeactivated;
            }

            mealCategory.IsDeleted = !mealCategory.IsDeleted;
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

            if (upsertDto.Name != mealCategory.Name)
            {
                await CheckIfMealCategoryNameExists(upsertDto.Name, mealCategoryId);
                mealCategory.Name = upsertDto.Name;
            }

            mealCategory.UpdateDate = DateTime.Now;

            if (upsertDto.Image != null)
            {
                ImageRespone imageRespone = await _fileHelper.Update(upsertDto.Image, mealCategory.ImageName);

                mealCategory.ImagePath = imageRespone.Path;
                mealCategory.ImageName = imageRespone.Name;
            }


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


        private async Task CheckIfMealCategoryNameExists(string mealCategoryName, int? mealCategoryId = null)
        {
            if (await _mealCategoryDal.AnyAsync(m => m.Name == mealCategoryName && !m.IsDeleted && (mealCategoryId.HasValue ? m.Id != mealCategoryId : true)))
                throw new EntityAlreadyExistsException("menü ismi");
        }


        private void CheckIfFileEnter(IFormFile? file)
        {
            if (file == null)
                throw new FileNotProvidedException();
        }

        #endregion
    }
}
