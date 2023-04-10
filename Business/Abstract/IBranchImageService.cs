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
    public interface IBranchImageService
    {
        IDataResult<List<BranchImage>> GetAll();
        IDataResult<BranchImage> Get(int id);
        IResult Add(IFormFile file, BranchImage branchImage);
        IResult Delete(BranchImage branchImage);
        IResult Update(IFormFile file, BranchImage branchImage);
    }
}
