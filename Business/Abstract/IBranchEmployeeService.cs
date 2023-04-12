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
        IDataResult<List<BranchEmployee>> GetAll();
        IDataResult<BranchEmployee> Get(int id);
        IResult Add(IFormFile file, BranchEmployee branchEmployee);
        IResult Delete(BranchEmployee branchEmployee);
        IResult Update(IFormFile file, BranchEmployee branchEmployee);
    }
}
