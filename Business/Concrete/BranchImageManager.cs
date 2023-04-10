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
    public class BranchImageManager : IBranchImageService
    {
        private IBranchImageDal _branchImageDal;

        public BranchImageManager(IBranchImageDal branchImageDal)
        {
            _branchImageDal = branchImageDal;
        }

        public IResult Add(IFormFile file, BranchImage branchImage)
        {
            var result = FileHelper.Upload(file, ImagePaths.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            branchImage.ImagePath = result.Data;

            _branchImageDal.Add(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageAdded);
        }

        public IResult Delete(BranchImage branchImage)
        {
            var result = FileHelper.Delete(branchImage.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            _branchImageDal.Delete(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageDeleted);
        }

        public IDataResult<BranchImage> Get(int id)
        {
            return new SuccessDataResult<BranchImage>(_branchImageDal.Get(b => b.Id == id), BranchImageMessages.BranchImageWasBrought);
        }

        public IDataResult<List<BranchImage>> GetAll()
        {
            return new SuccessDataResult<List<BranchImage>>(_branchImageDal.GetAll(), BranchImageMessages.BranchImagesListed);
        }

        public IResult Update(IFormFile file, BranchImage branchImage)
        {
            var result = FileHelper.Update(file, branchImage.ImagePath, ImagePaths.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            branchImage.ImagePath = result.Data;

            _branchImageDal.Update(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageUpdated);
        }
    }
}
