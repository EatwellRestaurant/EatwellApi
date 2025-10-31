using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.General
{
    public class CannotActivateEntityException : BadRequestBaseException
    {
        /// <summary>
        /// Bu {entityName} adı, başka bir {entityName}de kullanıldığı için aktif hale getirilemez.
        /// </summary>
        public CannotActivateEntityException(string entityName) : base($"Bu {entityName} adı, başka bir {entityName}de kullanıldığı için aktif hale getirilemez.")
        {
        }
    }
}
