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
    public interface IBranchEmployeeService
    {
        Task<IDataResult<List<BranchEmployee>>> GetAll();
        Task<IDataResult<BranchEmployee?>> Get(int id);
        Task<IResult> Add(IFormFile file, BranchEmployee branchEmployee);
        IResult Delete(BranchEmployee branchEmployee);
        Task<IResult> Update(IFormFile file, BranchEmployee branchEmployee);
    }
}
