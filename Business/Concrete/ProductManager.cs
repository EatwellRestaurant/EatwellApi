using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        readonly IFileHelper _fileHelper;

        public ProductManager(IProductDal productDal, IFileHelper fileHelper)
        {
            _productDal = productDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public async Task<IResult> Add(IFormFile file, ProductForCreateDto dto)
        {
            Product product = new Product
            {
                Name = dto.ProductName,
                Price = dto.Price,
                MealCategoryId = dto.MealCategoryId,
                ImagePath = _fileHelper.Upload(file).Result.Path
            };

            await _productDal.AddAsync(product);
            return new SuccessResult(ProductMessages.ProductAdded);
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

        [ValidationAspect(typeof(ProductValidator))]
        public async Task<IResult> Update(IFormFile file, ProductForUpdateDto dto)
        {
            Product product = new()
            {
                MealCategoryId = dto.MealCategoryId,
                Name = dto.ProductName,
                ImagePath = _fileHelper.Update(file, dto.ImagePath).Result.Path,
                Price = dto.Price,
            };


            _productDal.Update(product);
            return new SuccessResult(ProductMessages.ProductUpdated);
        }
    }
}
