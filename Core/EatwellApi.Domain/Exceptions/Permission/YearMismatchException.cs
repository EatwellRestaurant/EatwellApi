using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Permission
{
    public class YearMismatchException : BadRequestBaseException
    {
        /// <summary>
        /// İzin tarihleri seçilen yılla eşleşmiyor!
        /// </summary>
        public YearMismatchException() : base("İzin tarihleri seçilen yılla eşleşmiyor!")
        {
        }
    }
}
