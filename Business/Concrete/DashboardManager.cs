using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.ResponseModels;
using Entities.Dtos.Dashboard;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DashboardManager : IDashboardService
    {
        readonly IUserService _userService;
        readonly IMealCategoryService _mealCategoryService;

        public DashboardManager(IUserService userService, IMealCategoryService mealCategoryService)
        {
            _userService = userService;
            _mealCategoryService = mealCategoryService;
        }


        [SecuredOperation("admin")]
        public async Task<DataResponse<DashboardStatisticsDto>> GetStatistics()
        {
            DashboardStatisticsDto statisticsDto = new()
            {
                UserCount = await _userService.CountAsync(u => u.OperationClaimId != (byte)OperationClaimType.Admin && !u.IsDeleted),
                MealCategoryCount = await _mealCategoryService.CountAsync(m => !m.IsDeleted),
            };

            return new DataResponse<DashboardStatisticsDto>(statisticsDto, CommonMessages.EntityListed);
        }
    }
}
