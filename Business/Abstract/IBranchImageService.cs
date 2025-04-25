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
        Task<IDataResult<List<BranchImage>>> GetAll();
        Task<IDataResult<BranchImage?>> Get(int id);
        Task<IResult> Add(IFormFile file, BranchImage branchImage);
        IResult Delete(BranchImage branchImage);
        Task<IResult> Update(IFormFile file, BranchImage branchImage);
    }
}
