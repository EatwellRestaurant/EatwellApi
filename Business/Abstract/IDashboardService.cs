using Core.ResponseModels;
using Entities.Dtos.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDashboardService
    {
        Task<DataResponse<DashboardStatisticsDto>> GetStatistics();
    }
}
