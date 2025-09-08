using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.OperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<string> GetClaim(int operationClaimId);

        Task CheckIfOperationClaimIdExists(int operationClaimId);

        Task<List<OperationClaimListDto>> GetAllAsync();
    }
}
