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
        readonly IFileHelper _fileHelper;

        public BranchImageManager(IBranchImageDal branchImageDal, IFileHelper fileHelper)
        {
            _branchImageDal = branchImageDal;
            _fileHelper = fileHelper;
        }

        public async Task<IResult> Add(IFormFile file, BranchImage branchImage)
        {
            branchImage.ImagePath = _fileHelper.Upload(file).Result.Path;

            await _branchImageDal.AddAsync(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageAdded);
        }

        public IResult Delete(BranchImage branchImage)
        {
            _fileHelper.Delete(branchImage.ImagePath);

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

        public async Task<IResult> Update(IFormFile file, BranchImage branchImage)
        {
            branchImage.ImagePath = _fileHelper.Update(file, branchImage.ImagePath).Result.Path;

            _branchImageDal.Update(branchImage);
            return new SuccessResult(BranchImageMessages.BranchImageUpdated);
        }
    }
}
