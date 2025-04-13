using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.ResponseModels;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.MealCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        readonly IBranchDal _branchDal;
        readonly IMapper _mapper;

        public BranchManager(IBranchDal branchDal, IMapper mapper)
        {
            _branchDal = branchDal;
            _mapper = mapper;
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

         
        [SecuredOperation("admin")]
        public async Task<DataResponse<List<AdminBranchListDto>>> GetAllForAdmin()
        => new DataResponse<List<AdminBranchListDto>>(_mapper.Map<List<AdminBranchListDto>>
                (await _branchDal
                .GetAllQueryable()
                .OrderByDescending(m => m.CreateDate)
                .ToListAsync()),
                CommonMessages.EntityListed);


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
