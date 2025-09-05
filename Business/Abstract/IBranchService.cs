using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.Order;
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
        Task<object> GetAllForAdmin(PaginationRequest? paginationRequest);

        Task<PaginationResponse<BranchListDto>> GetAllForAdminByCityId(int cityId, PaginationRequest paginationRequest);

        Task<DataResponse<BranchDetailDto>> GetForAdmin(int branchId);

        Task<CreateSuccessResponse> Add(BranchInsertDto insertDto);

        Task<DeleteSuccessResponse> Delete(int branchId);
        
        Task<UpdateSuccessResponse> Update(int branchId, BranchUpdateDto updateDto);

        Task<DataResponse<List<BranchSalesDto>>> GetAllBranchesMonthlySalesAsync();

        Task<DataResponse<BranchOverviewDto>> GetBranchOverviewAsync();

        Task CheckIfBranchIdExists(int branchId);

    }
} 
