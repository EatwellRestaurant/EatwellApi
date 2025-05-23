﻿using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<PaginationResponse<ProductListDto>> GetAllForAdminByMealCategoryId(int mealCategoryId, PaginationRequest paginationRequest);

        Task<PaginationResponse<ProductListWithMealCategoryDto>> GetAllForAdmin(PaginationRequest paginationRequest);

        Task<DataResponse<ProductDetailDto>> GetForAdmin(int productId);
        
        Task<CreateSuccessResponse> Add(ProductInsertDto insertDto);

        Task<DeleteSuccessResponse> SetDeleteOrRestore(int productId);

        Task<DeleteSuccessResponse> Delete(int productId);

        Task<UpdateSuccessResponse> Update(int productId, ProductUpdateDto updateDto);
        
    }
}
