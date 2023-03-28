using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageCategoryManager : IImageCategoryService
    {
        private IImageCategoryDal _imageCategoryDal;

        public ImageCategoryManager(IImageCategoryDal imageCategoryDal)
        {
            _imageCategoryDal = imageCategoryDal;
        }


        public IResult Add(ImageCategory imageCategory)
        {
            _imageCategoryDal.Add(imageCategory);
            return new SuccessResult(ImageCategoryMessages.ImageCategoryAdded);
        }


        public IResult Delete(ImageCategory imageCategory)
        {
            _imageCategoryDal.Delete(imageCategory);
            return new SuccessResult(ImageCategoryMessages.ImageCategoryDeleted);
        }

        public IDataResult<ImageCategory> Get(int id)
        {
            return new SuccessDataResult<ImageCategory>(_imageCategoryDal.Get(i => i.Id == id), ImageCategoryMessages.ImageCategoryWasBrought);
        }

        public IDataResult<List<ImageCategory>> GetAll()
        {
            return new SuccessDataResult<List<ImageCategory>>(_imageCategoryDal.GetAll(), ImageCategoryMessages.ImageCategoriesListed);
        }

        public IResult Update(ImageCategory imageCategory)
        {
            _imageCategoryDal.Update(imageCategory);
            return new SuccessResult(ImageCategoryMessages.ImageCategoryUpdated);
        }
    }
}
