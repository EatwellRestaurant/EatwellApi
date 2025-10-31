using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Order
{
    public class OrderInsertDto : IDto
    {
        public int BranchId { get; set; }

        public int TableId { get; set; }

        public int? ReservationId { get; set; }

        public List<OrderProductDto> Products { get; set; }

    }
}
