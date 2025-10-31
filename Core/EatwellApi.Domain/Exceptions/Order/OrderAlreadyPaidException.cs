using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Order
{
    public class OrderAlreadyPaidException : BadRequestBaseException
    {
        /// <summary>
        /// Bu sipariş zaten ödenmiş!
        /// </summary>
        public OrderAlreadyPaidException() : base("Bu sipariş zaten ödenmiş!")
        {
        }
    }
}
