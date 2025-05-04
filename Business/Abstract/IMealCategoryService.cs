using Core.Requests;
using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Service.Abstract;

namespace Business.Abstract
{
    public interface IMealCategoryService : IService<MealCategory>
    {
        Task<PaginationResponse<MealCategoryListDto>> GetAllForAdmin(PaginationRequest paginationRequest);

        Task<DataResponse<MealCategoryDetailDto>> GetForAdmin(int mealCategoryId);
        
        Task<CreateSuccessResponse> Add(MealCategoryUpsertDto upsertDto);

        Task<UpdateSuccessResponse> Update(int mealCategoryId, MealCategoryUpsertDto upsertDto);
        
        Task<DeleteSuccessResponse> SetDeleteOrRestore(int mealCategoryId);

        Task<DeleteSuccessResponse> Delete(int mealCategoryId);
    }
}
