using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        Task<IResult> Add(IFormFile file, ProductForCreateDto product);
        IResult Delete(Product product);
        IResult Update(IFormFile file, ProductForUpdateDto product);
        Task<IDataResult<List<Product>>> GetProductsByMealCategoryId(int id);
    }
}
