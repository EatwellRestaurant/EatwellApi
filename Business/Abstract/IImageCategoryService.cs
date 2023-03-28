using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageCategoryService
    {
        IDataResult<List<ImageCategory>> GetAll();
        IDataResult<ImageCategory> Get(int id);
        IResult Add(ImageCategory imageCategory);
        IResult Delete(ImageCategory imageCategory);
        IResult Update(ImageCategory imageCategory);
    }
}
