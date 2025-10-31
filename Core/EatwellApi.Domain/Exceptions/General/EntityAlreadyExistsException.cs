using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.General
{
    public class EntityAlreadyExistsException : BadRequestBaseException
    {
        /// <summary>
        /// Bu {name} daha önce kullanılmış!
        /// </summary>
        public EntityAlreadyExistsException(string name) : base($"Bu {name} daha önce kullanılmış!")
        {
        }
    }
}
