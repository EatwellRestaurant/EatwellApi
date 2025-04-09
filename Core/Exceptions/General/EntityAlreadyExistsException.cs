using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.General
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
