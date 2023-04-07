using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(IFormFile file, Product product)
        {
            var result = FileHelper.Upload(file, ImagesPath.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            product.ImagePath = result.Data;

            _productDal.Add(product);
            return new SuccessResult(ProductMessages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            var result = FileHelper.Delete(product.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            _productDal.Delete(product);
            return new SuccessResult(ProductMessages.ProductDeleted);
        }

        public IDataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id), ProductMessages.ProductWasBrought);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), ProductMessages.ProductsListed);
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(IFormFile file, Product product)
        {
            var result = FileHelper.Update(file, product.ImagePath, ImagesPath.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            product.ImagePath = result.Data;

            _productDal.Update(product);
            return new SuccessResult(ProductMessages.ProductUpdated);
        }
    }
}
