using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<CreateSuccessResponse> Add(EmployeeUpsertDto employeeUpsertDto);
    }
}
