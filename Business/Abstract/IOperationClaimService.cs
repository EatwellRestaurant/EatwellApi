using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<DataResponse<List<OperationClaim>>> GetClaims(int userId);
    }
}
