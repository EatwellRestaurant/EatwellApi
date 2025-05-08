using Business.Abstract;
using Core.Requests;
using Entities.Concrete;
using Entities.Dtos.Reservation;
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
        public async Task<IActionResult> Get(int id)
        {
            var result = await _reservationService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllForAdmin(int branchId, [FromQuery] PaginationRequest paginationRequest) 
            => Ok(new ReservationPageDataDto
            {
                ReservationResponse = await _reservationService.GetAllForAdmin(branchId, paginationRequest),
                TableResponse = await _tableService.GetAllForAdmin(branchId)
            });
 
    }
}
