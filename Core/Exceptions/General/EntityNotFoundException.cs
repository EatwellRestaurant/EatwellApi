using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.General
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
