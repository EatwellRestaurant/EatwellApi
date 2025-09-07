using Core.ResponseModels;
using Entities.Dtos.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchStatisticsService
    {
        Task<DataResponse<BranchStatisticsDto>> GetStatistics(int? branchId);
    }
}
