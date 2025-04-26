using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
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

        public ProductManager(IProductDal productDal, IFileHelper fileHelper, IUnitOfWork unitOfWork, IMealCategoryService mealCategoryService, IMapper mapper)
        {
            _productDal = productDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
            _mealCategoryService = mealCategoryService;
            _mapper = mapper;
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(ProductUpsertDtoValidator))]
        public async Task<CreateSuccessResponse> Add(ProductUpsertDto upsertDto)
        {
            await CheckIfMealCategoryIdExists(upsertDto.MealCategoryId);

            await CheckIfProductNameExists(upsertDto.Name);

            _fileHelper.CheckIfFileEnter(upsertDto.Image);

            ImageRespone imageRespone = await _fileHelper.Upload(upsertDto.Image!);

            Product product = new()
            {
                Name = upsertDto.Name,
                Price = upsertDto.Price,
                MealCategoryId = upsertDto.MealCategoryId,
                ImagePath = imageRespone.Path,
                ImageName = imageRespone.Name,
            };

            await _productDal.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }

        public IResult Delete(Product product)
        {
            _fileHelper.Delete(product.ImagePath);

            _productDal.Remove(product);
            return new SuccessResult(ProductMessages.ProductDeleted);
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<DataResponse<ProductDetailDto>> GetForAdmin(int productId)
        {
            Product? product = await _productDal
               .GetAsNoTrackingAsync(p => p.Id == productId)
               ?? throw new EntityNotFoundException("Ürün");


            return new DataResponse<ProductDetailDto>
                (_mapper.Map<ProductDetailDto>(product),
                CommonMessages.EntityFetch);
        }


        [SecuredOperation("admin", Priority = 1)]
        public async Task<DataResponse<List<ProductListDto>>> GetAllForAdminByMealCategoryId(int mealCategoryId)
        {
            if (!await _mealCategoryService.AnyAsync(m => m.Id == mealCategoryId))
                throw new EntityNotFoundException("Menü");


            return new DataResponse<List<ProductListDto>>(_mapper.Map<List<ProductListDto>>
                    (await _productDal
                    .GetAllQueryable(p => p.MealCategoryId == mealCategoryId)
                    .OrderByDescending(p => p.CreateDate)
                    .ToListAsync()),
                    CommonMessages.EntityListed);
        }


        public async Task<IDataResult<List<Product>>> GetProductsByMealCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(p => p.MealCategoryId == id), ProductMessages.ProductsListed);
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(ProductUpsertDtoValidator))]
        public async Task<UpdateSuccessResponse> Update(int productId, ProductUpsertDto upsertDto)
        {
            Product product = await GetByIdProductForDeleteAndUpdate(productId);

            if (product.MealCategoryId != upsertDto.MealCategoryId) 
            {
                await CheckIfMealCategoryIdExists(upsertDto.MealCategoryId);
                product.MealCategoryId = upsertDto.MealCategoryId;
            }

            if (upsertDto.Name != product.Name)
            { 
                await CheckIfProductNameExists(upsertDto.Name, productId);
                product.Name = upsertDto.Name;
            }

            if (upsertDto.Image != null)
            {
                ImageRespone imageRespone = await _fileHelper.Update(upsertDto.Image, product.ImageName);

                product.ImagePath = imageRespone.Path;
                product.ImageName = imageRespone.Name;
            }

            product.Price = upsertDto.Price;
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
                .Where(p => p.Id == productId)
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
