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
using Entities.Concrete;
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

        public ProductManager(IProductDal productDal, IFileHelper fileHelper, IUnitOfWork unitOfWork, IMealCategoryService mealCategoryService)
        {
            _productDal = productDal;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
            _mealCategoryService = mealCategoryService;
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

        public async Task<IDataResult<Product?>> Get(int id)
        {
            return new SuccessDataResult<Product?>(await _productDal.GetAsync(p => p.Id == id), ProductMessages.ProductWasBrought);
        }

        public async Task<IDataResult<List<Product>>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(), ProductMessages.ProductsListed);
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
