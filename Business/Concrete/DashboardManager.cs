using Business.Abstract;
using Business.Constants.Messages;
using Core.ResponseModels;
using Entities.Dtos;
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



        public async Task<DataResponse<DashboardStatisticsDto>> GetStatistics()
        {
            DashboardStatisticsDto statisticsDto = new()
            {
                UserCount = await _userService.CountAsync(),
                MealCategoryCount = await _mealCategoryService.CountAsync(),
            };

            return new DataResponse<DashboardStatisticsDto>(statisticsDto, CommonMessages.EntityListed);
        }
    }
}
