using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Reservation
{
    public class NoAvailableTableException : BadRequestBaseException
    {
        /// <summary>
        /// Rezervasyon için uygun masa bulunamadı.
        /// </summary>
        public NoAvailableTableException() : base("Rezervasyon için uygun masa bulunamadı.")
        {
        }
    }
}
