using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
