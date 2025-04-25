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
        Task<IDataResult<List<Product>>> GetAll();
        
        Task<IDataResult<Product?>> Get(int id);
        
        Task<CreateSuccessResponse> Add(ProductUpsertDto upsertDto);
        
        IResult Delete(Product product);

        Task<UpdateSuccessResponse> Update(int productId, ProductUpsertDto upsertDto);
        
        Task<IDataResult<List<Product>>> GetProductsByMealCategoryId(int id);
    }
}
