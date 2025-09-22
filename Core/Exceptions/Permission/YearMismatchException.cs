using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Permission
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
