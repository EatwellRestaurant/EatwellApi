using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        public IResult Add(Branch branch)
        {
            _branchDal.Add(branch);
            return new SuccessResult(BranchMessages.BranchAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessResult(BranchMessages.BranchDeleted);
        }

        public IDataResult<Branch> Get(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b => b.Id == id), BranchMessages.BranchWasBrought);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), BranchMessages.BranchsListed);
        }


        [ValidationAspect(typeof(BranchValidator))]
        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(BranchMessages.BranchUpdated);
        }
    }
}
