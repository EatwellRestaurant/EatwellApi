using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.General
{
    public class EntityNotFoundException : NotFoundBaseException
    {
        /// <summary>
        /// {name} kaydı bulunamadı!
        /// </summary>
        public EntityNotFoundException(string name) : base($"{name} kaydı bulunamadı!")
        {
        }
    }
}
