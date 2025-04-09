using Business.Abstract;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        readonly IUserOperationClaimService _userOperationClaimService;

        public OperationClaimManager(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }



        public async Task<DataResponse<List<OperationClaim>>> GetClaims(int userId)
        {
             List<OperationClaim> operationClaims = await _userOperationClaimService
                .Where(u => u.UserId == userId)
                .Select(u => new OperationClaim
                {
                    Id = u.OperationClaim.Id,
                    Name = u.OperationClaim.Name,
                })
                .ToListAsync();


            return new DataResponse<List<OperationClaim>>(operationClaims);
        }
    }
}
