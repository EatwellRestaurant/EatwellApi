using Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeStatisticsDto
    {
        public int EmployeeCount { get; set; }

        public int ActiveEmployeeCount { get; set; }

        public int ChefCount { get; set; }

        public int WaiterCount { get; set; }

        public PaginationResponse<EmployeeListDto> EmployeeListDtos { get; set; }
    }
}