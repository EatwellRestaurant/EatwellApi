using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Permission
{
    public class OverlappingLeaveRequestException : BadRequestBaseException
    {
        /// <summary>
        /// Çalışan, seçilen tarihlerde daha önce izin kullanmıştır. Lütfen farklı bir tarih aralığı seçiniz.
        /// </summary>
        public OverlappingLeaveRequestException() : base("Çalışan, seçilen tarihlerde daha önce izin kullanmıştır. Lütfen farklı bir tarih aralığı seçiniz.")
        {
        }
    }
}
