using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(int id);
        IResult Add(IFormFile file, Product product);
        IResult Delete(Product product);
        IResult Update(IFormFile file, Product product);
        IDataResult<List<Product>> GetProductsByMealCategoryId(int id);
    }
}
