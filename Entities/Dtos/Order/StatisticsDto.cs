using Entities.Dtos.Branch;

namespace Entities.Dtos.Order
{
    public class StatisticsDto
    {
        public int OrderCount { get; set; }
        public int ReservationCount { get; set; }
        public decimal TotalSales { get; set; }

        public List<BranchSalesDto> BranchSalesDtos { get; set; }
    }
}