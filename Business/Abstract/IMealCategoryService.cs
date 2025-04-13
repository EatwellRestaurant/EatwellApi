using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealCategoryService : IService<MealCategory>
    {
        Task<DataResponse<List<MealCategoryListDto>>> GetAllForAdmin();

        Task<DataResponse<MealCategoryDetailDto>> GetForAdmin(int mealCategoryId);
        
        Task<CreateSuccessResponse> Add(MealCategoryUpsertDto upsertDto);

        Task<UpdateSuccessResponse> Update(int mealCategoryId, MealCategoryUpsertDto upsertDto);
        
        Task<DeleteSuccessResponse> SetDeleteOrRestore(int mealCategoryId);
    }
}
