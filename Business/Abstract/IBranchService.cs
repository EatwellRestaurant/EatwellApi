using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService : IService<Branch>
    {
        Task<DataResponse<List<BranchListWithCityDto>>> GetAllForAdmin();

        Task<DataResponse<List<BranchListDto>>> GetAllForAdminByCityId(int cityId);

        Task<DataResponse<BranchDetailDto>> GetForAdmin(int branchId);

        Task<CreateSuccessResponse> Add(BranchInsertDto insertDto);

        Task<DeleteSuccessResponse> Delete(int branchId);
        
        Task<UpdateSuccessResponse> Update(int branchId, BranchUpdateDto updateDto);
    }
} 
