using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.File
{
    public class FileSizeExceededException : BadRequestBaseException
    {
        /// <summary>
        /// Dosya boyutu, izin verilen maksimum sınırı aşıyor.
        /// </summary>
        public FileSizeExceededException() : base("Dosya boyutu, izin verilen maksimum sınırı aşıyor!")
        {
        }
    }
}
