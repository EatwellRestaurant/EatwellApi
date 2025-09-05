using Business.Abstract;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }



        public async Task<string> GetClaim(int operationClaimId)
        {
             string? operationClaimName = await _operationClaimDal
                .Where(o => o.Id == operationClaimId)
                .Select(o => o.Name)
                .SingleOrDefaultAsync()
                ?? 
                throw new EntityNotFoundException("Yetki");


            return operationClaimName;
        }



        public async Task CheckIfOperationClaimIdExists(int operationClaimId)
        {
            if (!await _operationClaimDal.AnyAsync(o => o.Id == operationClaimId))
                throw new EntityNotFoundException("Rol");
        }
    }
}
