using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Extensions;
using Business.ValidationRules.FluentValidation.EmployeeTask;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.EmployeeTask;
using Entities.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class EmployeeTaskManager : IEmployeeTaskService
    {
        readonly IEmployeeTaskDal _employeeTaskDal;
        readonly IEmployeeService _employeeService;
        readonly IMapper _mapper;

        public EmployeeTaskManager
            (IEmployeeTaskDal employeeTaskDal, 
            IEmployeeService employeeService, 
            IMapper mapper)
        {
            _employeeTaskDal = employeeTaskDal;
            _employeeService = employeeService;
            _mapper = mapper;
        }




        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(EmployeeTaskFilterRequestDtoValidator), Priority = 2)]
        public async Task<PaginationResponse<EmployeeTaskListDto>> GetEmployeeTaskFilteredAsync
            (int employeeId, EmployeeTaskFilterRequestDto employeeTaskFilterRequest, PaginationRequest paginationRequest)
        {
            await _employeeService.CheckIfEmployeeIdExists(employeeId);


            IQueryable<EmployeeTask> query = _employeeTaskDal
                .Where(e => !e.IsDeleted)
                .FilterByEmployeeId(employeeId)
                .FilterByPriorityLevel(employeeTaskFilterRequest.PriorityLevel)
                .FilterByTaskStatus(employeeTaskFilterRequest.TaskStatus)
                .AsNoTracking()
                .OrderByDescending(p => p.CreateDate);


            List<EmployeeTask> employeeTasks = await query
                .ApplyPagination(paginationRequest)
                .Select(e => new EmployeeTask
                {
                    Id = e.Id,
                    AssignedBy = new Employee() 
                    { 
                        User =  new User() 
                        {  
                            FirstName = e.AssignedBy.User.FirstName,
                            LastName = e.AssignedBy.User.LastName,
                        } 
                    },
                    Name = e.Name,
                    Description = e.Description,
                    PriorityLevel = e.PriorityLevel,
                    TaskStatus = e.TaskStatus,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    EmployeeSubTasks = e.EmployeeSubTasks
                    .Where(e => !e.IsDeleted)
                    .Select(es => new EmployeeSubTask()
                    {
                        CompletedDate = es.CompletedDate,
                    })
                    .ToList()
                })
                .ToListAsync();


            List<EmployeeTaskListDto> employeeTaskListDtos = _mapper.Map<List<EmployeeTaskListDto>>(employeeTasks);


            return new 
                (employeeTaskListDtos,
                paginationRequest,
                await query.CountAsync());
        }
    }
}
