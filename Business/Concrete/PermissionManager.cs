using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Extensions;
using Business.ValidationRules.FluentValidation.Permission;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Permission;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Permission;
using Entities.Enums.OperationClaim;
using Entities.Enums.Permission;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class PermissionManager : IPermissionService
    {
        readonly IPermissionDal _permissionDal;
        readonly IEmployeeService _employeeService;
        readonly IYearService _yearService;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly ILeaveRightService _leaveRightService;
        readonly ILeaveTypeService _leaveTypeService;

        public PermissionManager
            (IPermissionDal permissionDal,
            IEmployeeService employeeService,
            IYearService yearService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILeaveRightService leaveRightService,
            ILeaveTypeService leaveTypeService)
        {
            _permissionDal = permissionDal;
            _employeeService = employeeService;
            _yearService = yearService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _leaveRightService = leaveRightService;
            _leaveTypeService = leaveTypeService;
        }



        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(PermissionUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(PermissionUpsertDto permissionUpsertDto)
        {
            await _employeeService.CheckIfEmployeeIdExists((int)permissionUpsertDto.EmployeeId!);
            string year = await _yearService.CheckIfYearIdExists(permissionUpsertDto.YearId);

            if (year != permissionUpsertDto.StartDate.Year.ToString() || year != permissionUpsertDto.EndDate.Year.ToString())
                throw new YearMismatchException();

            var employeeLeaveData = await _employeeService
                .Where(e => e.Id == permissionUpsertDto.EmployeeId && !e.User.IsDeleted)
                .Select(e => new
                {
                    Permission = e.Permissions
                        .Where(p => (p.StartDate <= permissionUpsertDto.StartDate
                        && p.EndDate >= permissionUpsertDto.EndDate)
                        && !p.IsDeleted),

                    UsedLeaveDays = e.Permissions
                        .Where(p => p.LeaveTypeId == permissionUpsertDto.LeaveTypeId && !p.IsDeleted)
                        .Sum(p => EF.Functions.DateDiffDay(p.StartDate, p.EndDate) + 1),

                    HireDate = e.HireDate
                })
                .SingleAsync();

            if (employeeLeaveData.Permission.Any())
                throw new OverlappingLeaveRequestException();

            DateTime now = DateTime.Now;
            int years = now.Year - employeeLeaveData.HireDate.Year;

            // Eğer yıl dönümü gelmemişse 1 yıl eksiltiyoruz
            if (employeeLeaveData.HireDate.Date > now.AddYears(-years))
                years--;


            LeaveUsageInfo leaveUsageInfo = new()
            {
                UsedLeaveDays = employeeLeaveData.UsedLeaveDays,
                ExperienceInYears = years
            };


            LeaveRight leaveRights = await _leaveRightService
                .GetLeaveRightByTypeAsync(permissionUpsertDto.LeaveTypeId, permissionUpsertDto.YearId, leaveUsageInfo.ExperienceInYears);


            double requestedLeaveDays = (permissionUpsertDto.EndDate.Date - permissionUpsertDto.StartDate.Date).TotalDays + 1;


            if (leaveRights.DayCount < (requestedLeaveDays + leaveUsageInfo.UsedLeaveDays))
                throw new LeaveQuotaExceededException();


            await _permissionDal.AddAsync(_mapper.Map<Permission>(permissionUpsertDto));
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }



        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<List<PermissionListDto>>> GetEmployeePermissionsFilteredAsync(int employeeId, PermissionFilterRequestDto permissionFilterRequestDto)
        {
            await _employeeService.CheckIfEmployeeIdExists(employeeId);


            if (!permissionFilterRequestDto.YearId.HasValue)
                permissionFilterRequestDto.YearId = await _yearService.GetCurrentYearIdAsync();
            else
                await _yearService.CheckIfYearIdExists((int)permissionFilterRequestDto.YearId);
            
            

            if (permissionFilterRequestDto.LeaveTypeId.HasValue)
                await _leaveTypeService.CheckIfLeaveTypeIdExists((int)permissionFilterRequestDto.LeaveTypeId);


            List<Permission> permissions = await _permissionDal
                .Where(p => !p.IsDeleted)
                .FilterByEmployeeId(employeeId)
                .FilterByYearId((int)permissionFilterRequestDto.YearId)
                .FilterByLeaveTypeId(permissionFilterRequestDto.LeaveTypeId)
                .Include(p => p.LeaveType)
                .AsNoTracking()
                .OrderByDescending(p => p.CreateDate)
                .ToListAsync();


            return new DataResponse<List<PermissionListDto>>(
                _mapper.Map<List<PermissionListDto>>(permissions),
                CommonMessages.EntityListed);
        }

    }
}
