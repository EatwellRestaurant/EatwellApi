using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        Task<DataResponse<List<AdminBranchListDto>>> GetAllForAdmin();
       
        Task<DataResponse<BranchDetailDto>> GetForAdmin(int branchId);
        
        Task<CreateSuccessResponse> Add(BranchUpsertDto upsertDto);
        
        IResult Delete(Branch branch);
        
        Task<UpdateSuccessResponse> Update(int branchId, BranchUpsertDto upsertDto);
    }
}
