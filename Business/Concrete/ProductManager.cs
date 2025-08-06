using AutoMapper;
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
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Entities.Dtos.Product;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal _productDal;
        readonly IFileHelper _fileHelper;
        readonly IUnitOfWork _unitOfWork;
        readonly IMealCategoryService _mealCategoryService;
        readonly IMapper _mapper;

        public ProductManager(
            IProductDal productDal, 
            IFileHelper fileHelper, 
            IUnitOfWork unitOfWork, 
            IMealCategoryService mealCategoryService, 
            IMapper mapper)
        {
            _productDal = productDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
            _mealCategoryService = mealCategoryService;
            _mapper = mapper;
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(ProductUpsertDtoValidator))]
        public async Task<CreateSuccessResponse> Add(ProductInsertDto insertDto)
        {
            await CheckIfMealCategoryIdExists(insertDto.MealCategoryId);

            await CheckIfProductNameExists(insertDto.Name);

            _fileHelper.CheckIfFileEnter(insertDto.Image);

            ImageRespone imageRespone = await _fileHelper.Upload(insertDto.Image!);

            Product product = new()
            {
                Name = insertDto.Name,
                Price = insertDto.Price,
                MealCategoryId = insertDto.MealCategoryId,
                ImagePath = imageRespone.Path,
                ImageName = imageRespone.Name,
            };

            await _productDal.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }


        [SecuredOperation("admin")]
        public async Task<DeleteSuccessResponse> SetDeleteOrRestore(int productId)
        {
            Product product = await GetByIdProductForDeleteAndUpdate(productId);

            string responseMessage;

            if (!product.IsActive)
            {
                if (await _productDal.Where(p => p.Name == product.Name && p.Id != productId && !p.IsDeleted).AnyAsync())
                    throw new CannotActivateEntityException("ürün");

                responseMessage = ProductMessages.ProductActivated;
            }
            else
            {
                responseMessage = ProductMessages.ProductDeactivated;
            }

            product.IsActive = !product.IsActive;
            product.DeactivationDate = DateTime.Now;

            _productDal.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(responseMessage);
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<DeleteSuccessResponse> Delete(int productId)
        {
            Product product = await GetByIdProductForDeleteAndUpdate(productId);

            await _fileHelper.Delete(product.ImageName);

            product.IsDeleted = true;
            product.DeleteDate = DateTime.Now;

            _productDal.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(CommonMessages.EntityDeleted);
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<DataResponse<ProductDetailDto>> GetForAdmin(int productId)
        {
            Product? product = await _productDal
               .GetAsNoTrackingAsync(p => p.Id == productId && !p.IsDeleted)
               ?? throw new EntityNotFoundException("Ürün");


            return new DataResponse<ProductDetailDto>
                (_mapper.Map<ProductDetailDto>(product),
                CommonMessages.EntityFetch);
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<PaginationResponse<ProductAdminListDto>> GetAllForAdminByMealCategoryId(int mealCategoryId, PaginationRequest paginationRequest)
        {
            if (!await _mealCategoryService.AnyAsync(m => m.Id == mealCategoryId && !m.IsDeleted))
                throw new EntityNotFoundException("Menü");

            IQueryable<Product> query = _productDal
                    .GetAllQueryable(p => p.MealCategoryId == mealCategoryId && !p.IsDeleted);

            List<ProductAdminListDto> productListDtos = _mapper.Map<List<ProductAdminListDto>>
                    (await query
                    .OrderByDescending(p => p.CreateDate)
                    .ApplyPagination(paginationRequest)
                    .ToListAsync());

            return new PaginationResponse<ProductAdminListDto>(productListDtos, paginationRequest, await query.CountAsync());
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<PaginationResponse<ProductListWithMealCategoryDto>> GetAllForAdmin(PaginationRequest paginationRequest)
        {
            IQueryable<Product> query = _productDal
               .GetAllQueryable(p => !p.IsDeleted);

            List<ProductListWithMealCategoryDto> productLists = _mapper.Map<List<ProductListWithMealCategoryDto>>
               (await query
               .Include(p => p.MealCategory)
               .OrderByDescending(p => p.CreateDate)
               .ApplyPagination(paginationRequest)
               .ToListAsync());
    
            return new PaginationResponse<ProductListWithMealCategoryDto>(productLists,paginationRequest, await query.CountAsync());
        }


        public async Task<object> GetAll(PaginationRequest? paginationRequest)
        {
            IQueryable<Product> query = _productDal
               .GetAllQueryable(p => !p.IsDeleted && p.IsActive);
            
            List<ProductDisplayDto> productListDtos = _mapper.Map<List<ProductDisplayDto>>
               (await query
               .OrderByDescending(p => p.CreateDate)
               .ApplyPagination(paginationRequest)
               .ToListAsync());

            return paginationRequest != null 
                ? new PaginationResponse<ProductDisplayDto>(productListDtos, paginationRequest, await query.CountAsync())
                : new DataResponse<List<ProductDisplayDto>>(productListDtos, CommonMessages.EntityListed);
        }


        public async Task<DataResponse<List<ProductDisplayDto>>> GetSelectedProducts()
        {
            List<Product> products = await _productDal
                .GetAllQueryable(p => !p.IsDeleted && p.IsActive && p.IsSelected)
                .OrderBy(p => p.Order)
                .ToListAsync();

            return new DataResponse<List<ProductDisplayDto>>(_mapper.Map<List<ProductDisplayDto>>(products), CommonMessages.EntityListed);
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(ProductUpsertDtoValidator))]
        public async Task<UpdateSuccessResponse> Update(int productId, ProductUpdateDto updateDto)
        {
            Product product = await GetByIdProductForDeleteAndUpdate(productId);

            if (updateDto.Name != product.Name)
            { 
                await CheckIfProductNameExists(updateDto.Name, productId);
                product.Name = updateDto.Name;
            }

            if (updateDto.Image != null)
            {
                ImageRespone imageRespone = await _fileHelper.Update(updateDto.Image, product.ImageName);

                product.ImagePath = imageRespone.Path;
                product.ImageName = imageRespone.Name;
            }

            product.Price = updateDto.Price;
            product.UpdateDate = DateTime.Now;

            _productDal.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }





        #region BusinessRules

        private async Task CheckIfProductNameExists(string productName, int? productId = null)
        {
            if (await _productDal.AnyAsync(p => p.Name == productName && !p.IsDeleted && (productId.HasValue ? p.Id != productId : true)))
                throw new EntityAlreadyExistsException("ürün ismi");
        }


        private async Task<Product> GetByIdProductForDeleteAndUpdate(int productId)
        {
            Product? product = await _productDal
                .Where(p => p.Id == productId && !p.IsDeleted)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Ürün");


            return product;
        }


        private async Task CheckIfMealCategoryIdExists(int mealCategoryId)
        {
            if (!await _mealCategoryService.AnyAsync(m => m.Id == mealCategoryId && !m.IsDeleted))
                throw new EntityNotFoundException("Menü");
        }

        #endregion
    }
}
