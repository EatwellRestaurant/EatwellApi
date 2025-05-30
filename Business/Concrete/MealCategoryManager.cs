﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.Extensions;
using Core.Requests;
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
            await CheckIfMealCategoryNameExists(upsertDto.Name);

            _fileHelper.CheckIfFileEnter(upsertDto.Image);

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

            if (!mealCategory.IsActive)
            {
                if (await _mealCategoryDal.Where(m => m.Name == mealCategory.Name && m.Id != mealCategoryId && !m.IsDeleted).AnyAsync())
                    throw new CannotActivateEntityException("menü");

                responseMessage = MealCategoryMessages.MealCategoryActivated;
            }
            else
            {
                responseMessage = MealCategoryMessages.MealCategoryDeactivated;
            }

            mealCategory.IsActive = !mealCategory.IsActive;
            mealCategory.DeactivationDate = DateTime.Now;

            _mealCategoryDal.Update(mealCategory);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(responseMessage);
        }



        [SecuredOperation("admin", Priority = 1)]
        public async Task<DeleteSuccessResponse> Delete(int mealCategoryId)
        {
            MealCategory? mealCategory = await _mealCategoryDal
                .Where(m => m.Id == mealCategoryId && !m.IsDeleted)
                .Include(m => m.Products)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Menü");


            if (mealCategory.Products.Any())
            {
                foreach (Product product in mealCategory.Products)
                {
                    if (!product.IsDeleted)
                    {
                        product.IsDeleted = true;
                        product.DeleteDate = DateTime.Now;
                        await _fileHelper.Delete(product.ImageName);
                    }
                }
            }

            mealCategory.IsDeleted = true;
            mealCategory.DeleteDate = DateTime.Now;

            _mealCategoryDal.Update(mealCategory);
            await _unitOfWork.SaveChangesAsync();

            await _fileHelper.Delete(mealCategory.ImageName);

            return new DeleteSuccessResponse(CommonMessages.EntityDeleted);
        }



        [SecuredOperation("admin")]
        public async Task<DataResponse<MealCategoryDetailDto>> GetForAdmin(int mealCategoryId)
        {
            MealCategory? mealCategory = await _mealCategoryDal
                .GetAsNoTrackingAsync(m => m.Id == mealCategoryId && !m.IsDeleted)
                ?? throw new EntityNotFoundException("Menü");

            return new DataResponse<MealCategoryDetailDto>
                (_mapper.Map<MealCategoryDetailDto>(mealCategory), 
                CommonMessages.EntityFetch);
        }



        [SecuredOperation("admin")]
        public async Task<object> GetAllForAdmin(PaginationRequest? paginationRequest)
        {
            IQueryable<MealCategory> query = _mealCategoryDal
                .GetAllQueryable(m => !m.IsDeleted);

            List<MealCategoryListDto> mealCategoryListDtos = _mapper.Map<List<MealCategoryListDto>>
                (await query
                .OrderByDescending(m => m.CreateDate)
                .ApplyPagination(paginationRequest)
                .ToListAsync());

            return paginationRequest != null 
                ? new PaginationResponse<MealCategoryListDto>(mealCategoryListDtos, paginationRequest, await query.CountAsync())
                : new DataResponse<List<MealCategoryListDto>>(mealCategoryListDtos, CommonMessages.EntityListed);
        }



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
                .Where(m => m.Id == mealCategoryId && !m.IsDeleted)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Menü");


            return mealCategory;
        }


        private async Task CheckIfMealCategoryNameExists(string mealCategoryName, int? mealCategoryId = null)
        {
            if (await _mealCategoryDal.AnyAsync(m => m.Name == mealCategoryName && !m.IsDeleted && (mealCategoryId.HasValue ? m.Id != mealCategoryId : true)))
                throw new EntityAlreadyExistsException("menü ismi");
        }

        #endregion
    }
}
