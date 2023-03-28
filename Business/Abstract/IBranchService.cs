using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<List<Branch>> GetAll();
        IDataResult<Branch> Get(int id);
        IResult Add(Branch branch);
        IResult Delete(Branch branch);
        IResult Update(Branch branch);
    }
}
