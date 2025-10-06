using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.EmployeeTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeTaskService
    {
        Task<PaginationResponse<EmployeeTaskListDto>> GetEmployeeTaskFilteredAsync(int employeeId, EmployeeTaskFilterRequestDto employeeTaskFilterRequest, PaginationRequest paginationRequest);

    }
} 
 