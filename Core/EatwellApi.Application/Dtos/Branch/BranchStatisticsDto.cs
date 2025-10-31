using EatwellApi.Application.Dtos.HeadOffice;

namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchStatisticsDto
    {
        public int OrderCount { get; set; }
        public int ReservationCount { get; set; }
        public decimal TotalSales { get; set; }

        public List<BranchSalesDto> BranchSalesDtos { get; set; }

        public BranchOverviewDto BranchOverviewDto { get; set; }

        public HeadOfficeDto HeadOfficeDto { get; set; }
    }
}