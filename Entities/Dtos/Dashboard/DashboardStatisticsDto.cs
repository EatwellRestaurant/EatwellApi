using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Dashboard
{
    public class DashboardStatisticsDto : IDto
    {
        public int UserCount { get; set; }
        public int MealCategoryCount { get; set; }
        public int OrderCount { get; set; }
        public int ReservationCount { get; set; }
    }
}
