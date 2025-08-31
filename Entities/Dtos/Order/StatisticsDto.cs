using Entities.Dtos.Branch;
using Entities.Dtos.HeadOffice;

namespace Entities.Dtos.Order
{
    public class StatisticsDto
    {
        public int OrderCount { get; set; }
        public int ReservationCount { get; set; }
        public decimal TotalSales { get; set; }

        public List<BranchSalesDto> BranchSalesDtos { get; set; }

        public BranchOverviewDto BranchOverviewDto { get; set; }

        public HeadOfficeDto HeadOfficeDto { get; set; }
    }
}