using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Extensions;
using Business.ValidationRules.FluentValidation.EmployeeTask;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.EmployeeTask;
using Entities.Enums.EmployeeTask;
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
        public async Task<PaginationResponse<EmployeeTaskListDto>> GetEmployeeTasksAsync
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




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<EmployeeTaskStatisticsDto>> GetStatisticsAsync(int employeeId)
        {
            IQueryable<EmployeeTask> query = _employeeTaskDal
                .Where(e => e.AssigneeId == employeeId && !e.IsDeleted);


            EmployeeTaskStatisticsDto employeeTaskStatisticsDto = new()
            {
                TotalTaskCount = await query
                .CountAsync(),

                CompletedTaskCount = await query
                .FilterByTaskStatus(TaskStatusEnum.Completed)
                .CountAsync(),

                InProgressTaskCount = await query
                .FilterByTaskStatus(TaskStatusEnum.InProgress)
                .CountAsync(),

                PendingTaskCount = await query
                .FilterByTaskStatus(TaskStatusEnum.Pending)
                .CountAsync()
            };


            return new(employeeTaskStatisticsDto, CommonMessages.StatisticsFetch);
        }





        [SecuredOperation(OperationClaimEnum.Admin)]
        public DataResponse<EmployeeTaskFilterOptionsDto> GetFilterOptions()
            => new(
                new()
                {
                    PriorityLevelDtos = EnumHelper.ToLookupList<PriorityLevelEnum, PriorityLevelDto>(),
                    TaskStatusDtos = EnumHelper.ToLookupList<TaskStatusEnum, TaskStatusDto>()
                });
    }
}
