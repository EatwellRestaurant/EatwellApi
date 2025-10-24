using Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeTask
{
    public class EmployeeTaskOverviewDto
    {
        public DataResponse<EmployeeTaskStatisticsDto> Statistics { get; set; }

        public DataResponse<EmployeeTaskFilterOptionsDto> FilterOptions { get; set; }

        public PaginationResponse<EmployeeTaskListDto> Tasks { get; set; }

    }
}
