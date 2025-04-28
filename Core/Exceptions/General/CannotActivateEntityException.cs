using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.General
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
