using Core.ResponseModels;
using Entities.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchStatisticsService
    {
        Task<DataResponse<StatisticsDto>> GetStatistics(int? branchId);
    }
}
