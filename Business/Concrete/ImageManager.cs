using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
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
    public class ImageManager : IImageService
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, Image image)
        {
            var result = FileHelper.Upload(file, ImagesPath.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            image.Path = result.Data;

            _imageDal.Add(image);
            return new SuccessResult(ImageMessages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            var result = FileHelper.Delete(image.Path);

            if (!result.Success)
            {
                return result;
            }

            _imageDal.Delete(image);
            return new SuccessResult(ImageMessages.ImageDeleted);
        }

        public IDataResult<Image> Get(int imageId)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i => i.Id == imageId), ImageMessages.ImageWasBrought);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(), ImageMessages.ImagesListed);
        }

        public IDataResult<List<Image>> GetByImageCategoryId(int imageCategoryId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.ImageCategoryId == imageCategoryId));
        }

        public IResult Update(IFormFile file, Image image)
        {
            var result = FileHelper.Update(file, image.Path, ImagesPath.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            _imageDal.Update(image);
            return new SuccessResult(ImageMessages.ImageUpdated);
        }
    }
}
