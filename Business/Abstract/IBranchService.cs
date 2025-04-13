using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        Task<DataResponse<List<AdminBranchListDto>>> GetAllForAdmin();
        Task<IDataResult<Branch?>> Get(int id);
        Task<IResult> Add(Branch branch);
        IResult Delete(Branch branch);
        IResult Update(Branch branch);
    }
}
