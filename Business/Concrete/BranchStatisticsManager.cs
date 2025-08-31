using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.ResponseModels;
using Entities.Dtos.Branch;
using Entities.Dtos.HeadOffice;
using Entities.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchStatisticsManager : IBranchStatisticsService
    {
        readonly IOrderService _orderService;
        readonly IReservationService _reservationService;
        readonly IBranchService _branchService;
        readonly IHeadOfficeService _headOfficeService;

        public BranchStatisticsManager
            (IReservationService reservationService, 
            IOrderService orderService, 
            IBranchService branchService, 
            IHeadOfficeService headOfficeService)
        {
            _reservationService = reservationService;
            _orderService = orderService;
            _branchService = branchService;
            _headOfficeService = headOfficeService;
        }




        [SecuredOperation("admin")]
        public async Task<DataResponse<StatisticsDto>> GetStatistics(int? branchId)
        {
            DataResponse<int> orderCount = await _orderService.GetOrderCount(branchId);
            DataResponse<int> reservationCount = await _reservationService.GetReservationCount(branchId);
            DataResponse<decimal> totalSales = await _orderService.CalculateTotalSales(branchId);
            DataResponse<List<BranchSalesDto>> branchSales = await _branchService.GetAllBranchesMonthlySalesAsync();
            DataResponse<BranchOverviewDto> branchOverview = await _branchService.GetBranchOverviewAsync();
            DataResponse<HeadOfficeDto> headOffice = await _headOfficeService.GetAsync();

            return new DataResponse<StatisticsDto>(new StatisticsDto
            {
                OrderCount = orderCount.Data,
                ReservationCount = reservationCount.Data,
                TotalSales = totalSales.Data,
                BranchSalesDtos = branchSales.Data,
                BranchOverviewDto = branchOverview.Data,
                HeadOfficeDto = headOffice.Data,
            }, 
            CommonMessages.StatisticsFetch);
        }
    }
}
