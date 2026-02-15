using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class ForbiddenException : ForbiddenBaseException
    {
        /// <summary>
        /// Yetkiniz yok!
        /// </summary>
        public ForbiddenException() : base("Yetkiniz yok!")
        {
        }


        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
