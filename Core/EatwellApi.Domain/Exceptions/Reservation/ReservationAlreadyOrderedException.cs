using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Reservation
{
    public class ReservationAlreadyOrderedException : BadRequestBaseException
    {
        /// <summary>
        /// Bu rezervasyon için zaten sipariş verilmiş!
        /// </summary>
        public ReservationAlreadyOrderedException() : base("Bu rezervasyon için zaten sipariş verilmiş!")
        {
        }
    }
}
