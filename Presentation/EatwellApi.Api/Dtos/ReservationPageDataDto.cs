using EatwellApi.Application.Dtos.Reservation;
using EatwellApi.Application.Dtos.Table;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Api.Dtos
{
    public class ReservationPageDataDto
    {
        public PaginationResponse<ReservationListDto> ReservationResponse { get; set; }

        public DataResponse<List<TableListDto>> TableResponse { get; set; }
    }
}
