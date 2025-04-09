using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class BranchManager : IBranchService
    {
        private IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BranchValidator))]
        public async Task<IResult> Add(Branch branch)
        {
            var result = BusinessRules.Run(
                await CheckIfBranchNameExixts(branch.Name),
                await CheckIfBranchAddressExixts(branch.Address));

            if (!result.Success)
            {
                return result;
            }

            await _branchDal.AddAsync(branch);
            return new SuccessResult(BranchMessages.BranchAdded);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Branch branch)
        {
            _branchDal.Remove(branch);
            return new SuccessResult(BranchMessages.BranchDeleted);
        }


        [SecuredOperation("admin")]
        public async Task<IDataResult<Branch?>> Get(int id)
        {
            return new SuccessDataResult<Branch?>(await _branchDal.GetAsync(b => b.Id == id), BranchMessages.BranchWasBrought);
        }


        public async Task<IDataResult<List<Branch>>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(await _branchDal.GetAllAsync(), BranchMessages.BranchesListed);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BranchValidator))]
        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(BranchMessages.BranchUpdated);
        }
       




        //Business Rules
        private async Task<IResult> CheckIfBranchNameExixts(string branchName)
        {
            var result = await _branchDal.AnyAsync(b => b.Name == branchName);

            if (result)
            {
                return new ErrorResult(BranchMessages.BranchNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckIfBranchAddressExixts(string branchAddress)
        {
            var result = await _branchDal.AnyAsync(b => b.Address == branchAddress);

            if (result)
            {
                return new ErrorResult(BranchMessages.BranchAddressAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
