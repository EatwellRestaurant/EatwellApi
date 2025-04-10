using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Constants.Paths;
using Core.Utilities.Business;
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
    public class BranchEmployeeManager : IBranchEmployeeService
    {
        private IBranchEmployeeDal _branchEmployeeDal;
        readonly IFileHelper _fileHelper;

        public BranchEmployeeManager(IBranchEmployeeDal branchEmployeeDal, IFileHelper fileHelper)
        {
            _branchEmployeeDal = branchEmployeeDal;
            _fileHelper = fileHelper;
        }

        public async Task<IResult> Add(IFormFile file, BranchEmployee branchEmployee)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file));

            if (result.Success)
            {
                var resultOfUpload = _fileHelper.Upload(file);

                if (!resultOfUpload.Success)
                {
                    return result;
                }
                branchEmployee.ImagePath = resultOfUpload.Data;
            }

            await _branchEmployeeDal.AddAsync(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeAdded);
        }

        public IResult Delete(BranchEmployee branchEmployee)
        {
            var result = BusinessRules.Run(CheckIfImagePathIsEmpty(branchEmployee.ImagePath));

            if (result.Success) 
            { 
                var resultOfDelete = _fileHelper.Delete(branchEmployee.ImagePath);

                if (!resultOfDelete.Success)
                {
                    return result;
                }
            }
        
            _branchEmployeeDal.Remove(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeDeleted);
        }

        public async Task<IDataResult<BranchEmployee?>> Get(int id)
        {
            return new SuccessDataResult<BranchEmployee?>(await _branchEmployeeDal.GetAsync(b => b.Id == id), 
                BranchEmployeeMessages.BranchEmployeeWasBrought);
        }

        public async Task<IDataResult<List<BranchEmployee>>> GetAll()
        {
            return new SuccessDataResult<List<BranchEmployee>>(await _branchEmployeeDal.GetAllAsync(),
                BranchEmployeeMessages.BranchEmployeesListed);
        }

        public async Task<IResult> Update(IFormFile file, BranchEmployee branchEmployee)
        {
            var employee = await _branchEmployeeDal.GetAsync(b => b.Id == branchEmployee.Id);

            if (CheckIfFileEnter(file).Success)
            {
                if (CheckIfImagePathIsEmpty(employee.ImagePath).Success)
                {
                    var resultOfUpdate = _fileHelper.Update(file, employee.ImagePath, ImagePaths.ImagePath);

                    if (!resultOfUpdate.Success)
                    {
                        return resultOfUpdate;
                    }
                    branchEmployee.ImagePath = resultOfUpdate.Data;
                }
                else
                {
                    var resultOfAdd = _fileHelper.Upload(file);

                    if (!resultOfAdd.Success)
                    {
                        return resultOfAdd;
                    }
                    branchEmployee.ImagePath = resultOfAdd.Data;
                }
            }

            _branchEmployeeDal.Update(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeUpdated);
        }



        //Business Codes
        private IResult CheckIfImagePathIsEmpty(string imagePath)
        {
            if(imagePath != null)
            {
                return new SuccessResult("ImagePath is full");
            }
            return new ErrorResult("ImagePath is null");
        }

        private static IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }
    }
}
