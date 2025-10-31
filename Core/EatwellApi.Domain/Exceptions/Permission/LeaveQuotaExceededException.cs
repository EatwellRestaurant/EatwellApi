using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Permission
{
    public class LeaveQuotaExceededException : BadRequestBaseException
    {
        /// <summary>
        /// Kullanmak istediğiniz izin günleriyle birlikte belirlenen izin süresini geçmiş oluyorsunuz.
        /// </summary>
        public LeaveQuotaExceededException() : base("Kullanmak istediğiniz izin günleriyle birlikte belirlenen izin süresini geçmiş oluyorsunuz!")
        {
        }
    }
}
