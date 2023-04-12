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

        public BranchEmployeeManager(IBranchEmployeeDal branchEmployeeDal)
        {
            _branchEmployeeDal = branchEmployeeDal;
        }

        public IResult Add(IFormFile file, BranchEmployee branchEmployee)
        {
            var result = BusinessRules.Run(ChechIfImagePathIsEmpty(branchEmployee.ImagePath));

            if (result.Success)
            {
                var resultOfUpload = FileHelper.Upload(file, ImagePaths.ImagePath);

                if (!resultOfUpload.Success)
                {
                    return result;
                }
            }

            _branchEmployeeDal.Add(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeAdded);
        }

        public IResult Delete(BranchEmployee branchEmployee)
        {
            var result = BusinessRules.Run(ChechIfImagePathIsEmpty(branchEmployee.ImagePath));

            if (result.Success) 
            { 
                var resultOfDelete = FileHelper.Delete(branchEmployee.ImagePath);

                if (!resultOfDelete.Success)
                {
                    return result;
                }
            }
        
            _branchEmployeeDal.Delete(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeDeleted);
        }

        public IDataResult<BranchEmployee> Get(int id)
        {
            return new SuccessDataResult<BranchEmployee>(_branchEmployeeDal.Get(b => b.Id == id), 
                BranchEmployeeMessages.BranchEmployeeWasBrought);
        }

        public IDataResult<List<BranchEmployee>> GetAll()
        {
            return new SuccessDataResult<List<BranchEmployee>>(_branchEmployeeDal.GetAll(),
                BranchEmployeeMessages.BranchEmployeeWasBrought);
        }

        public IResult Update(IFormFile file, BranchEmployee branchEmployee)
        {
            var result = BusinessRules.Run(ChechIfImagePathIsEmpty(branchEmployee.ImagePath));

            if (result.Success)
            {
                var resultOfUpdate = FileHelper.Update(file, branchEmployee.ImagePath, ImagePaths.ImagePath);

                if (!resultOfUpdate.Success)
                {
                    return result;
                }
            }

            _branchEmployeeDal.Update(branchEmployee);
            return new SuccessResult(BranchEmployeeMessages.BranchEmployeeUpdated);
        }



        //Business Codes
        private IResult ChechIfImagePathIsEmpty(string imagePath)
        {
            if(imagePath != null)
            {
                return new SuccessResult("ImagePath is full");
            }
            return new ErrorResult("ImagePath is null");
        }
    }
}
