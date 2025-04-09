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

        public async Task<IResult> Add(IFormFile file, BranchImage branchImage)
        {
            var result = FileHelper.Upload(file, ImagePaths.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            branchImage.ImagePath = result.Data;

            await _branchImageDal.AddAsync(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageAdded);
        }

        public IResult Delete(BranchImage branchImage)
        {
            var result = FileHelper.Delete(branchImage.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            _branchImageDal.Remove(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageDeleted);
        }

        public async Task<IDataResult<BranchImage?>> Get(int id)
        {
            return new SuccessDataResult<BranchImage?>(await _branchImageDal.GetAsync(b => b.Id == id), BranchImageMessages.BranchImageWasBrought);
        }

        public async Task<IDataResult<List<BranchImage>>> GetAll()
        {
            return new SuccessDataResult<List<BranchImage>>(await _branchImageDal.GetAllAsync(), BranchImageMessages.BranchImagesListed);
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
