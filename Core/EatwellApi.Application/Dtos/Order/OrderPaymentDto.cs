using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Order
{
    public class OrderPaymentDto : IDto
    {
        public byte PaymentMethod { get; set; }
    }
}
