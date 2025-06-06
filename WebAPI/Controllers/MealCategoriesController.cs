﻿using Business.Abstract;
using Core.Requests;
using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealCategoriesController : ControllerBase
    {
        private IMealCategoryService _mealCategoryService;

        public MealCategoriesController(IMealCategoryService mealCategoryService)
        {
            _mealCategoryService = mealCategoryService;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] MealCategoryUpsertDto upsertDto) 
            => Ok(await _mealCategoryService.Add(upsertDto));
        
        

        [HttpDelete]
        public async Task<IActionResult> SetDeleteOrRestore(int mealCategoryId) 
            => Ok(await _mealCategoryService.SetDeleteOrRestore(mealCategoryId));
        
        

        [HttpDelete]
        public async Task<IActionResult> Delete(int mealCategoryId) 
            => Ok(await _mealCategoryService.Delete(mealCategoryId));
         


        [HttpPut]
        public async Task<IActionResult> Update(int mealCategoryId, [FromForm] MealCategoryUpsertDto upsertDto) 
            => Ok(await _mealCategoryService.Update(mealCategoryId, upsertDto));
        


        [HttpGet]
        public async Task<IActionResult> GetForAdmin(int mealCategoryId) 
            => Ok(await _mealCategoryService.GetForAdmin(mealCategoryId));



        [HttpGet]
        public async Task<IActionResult> GetAllForAdmin([FromQuery] PaginationRequest? paginationRequest)
        {
            if (paginationRequest!.PageNumber == 0 ||  paginationRequest.PageSize == 0)
                paginationRequest = null;

            return Ok(await _mealCategoryService.GetAllForAdmin(paginationRequest));
        }
    }
}
