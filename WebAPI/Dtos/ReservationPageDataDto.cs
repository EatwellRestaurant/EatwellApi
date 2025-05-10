using Core.ResponseModels;
using Entities.Dtos.Reservation;
using Entities.Dtos.Table;

namespace WebAPI.Dtos
{
    public class ReservationPageDataDto
    {
        public PaginationResponse<ReservationListDto> ReservationResponse { get; set; }

        public DataResponse<List<TableListDto>> TableResponse { get; set; }
    }
} 
