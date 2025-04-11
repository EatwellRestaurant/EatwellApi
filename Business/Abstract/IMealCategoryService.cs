using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        Task<IDataResult<MealCategory?>> Get(int id);
        Task<CreateSuccessResponse> Add(MealCategoryUpsertDto upsertDto);
        IResult Update(IFormFile file, MealCategory mealCategory);
        Task<DeleteSuccessResponse> SetDeleteOrRestore(int mealCategoryId);
    }
}
