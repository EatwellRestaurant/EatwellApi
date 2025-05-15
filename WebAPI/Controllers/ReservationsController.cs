using Business.Abstract;
using Core.Requests;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using Entities.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        readonly IReservationService _reservationService;
        readonly ITableService _tableService;

        public ReservationsController(IReservationService reservationService, ITableService tableService)
        {
            _reservationService = reservationService;
            _tableService = tableService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(ReservationUpsertDto upsertDto) 
            => Ok(await _reservationService.Add(upsertDto));
        
        

        [HttpDelete]
        public IActionResult Delete(Reservation reservation)
        {
            var result = _reservationService.Delete(reservation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Reservation reservation)
        {
            var result = _reservationService.Update(reservation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet]
        public async Task<IActionResult> Get(int reservationId) 
            => Ok(await _reservationService.Get(reservationId));



        [HttpGet]
        public async Task<IActionResult> GetAdminDashboardReservationData(int branchId, [FromQuery] PaginationRequest paginationRequest, [FromQuery] ReservationFilter reservationFilter) 
            => Ok(new ReservationPageDataDto
            {
                ReservationResponse = await _reservationService.GetAllForAdmin(branchId, paginationRequest, reservationFilter),
                TableResponse = await _tableService.GetAllForAdmin(branchId)
            });
        
        

        [HttpGet]
        public async Task<IActionResult> GetAllForAdmin(int branchId, [FromQuery] PaginationRequest paginationRequest, [FromQuery] ReservationFilter reservationFilter) 
            => Ok(await _reservationService.GetAllForAdmin(branchId, paginationRequest, reservationFilter));
 
    }
} 
