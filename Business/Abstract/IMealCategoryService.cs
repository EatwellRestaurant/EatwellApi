using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealCategoryService
    {
        Task<IDataResult<List<MealCategory>>> GetAll();
        Task<IDataResult<MealCategory?>> Get(int id);
        Task<IResult> Add(MealCategoryUpsertDto upsertDto);
        IResult Update(IFormFile file, MealCategory mealCategory);
        IResult Delete(MealCategory mealCategory);
    }
}
