using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.File
{
    public class FileNotProvidedException : BadRequestBaseException
    {
        /// <summary>
        /// Lütfen bir resim dosyası giriniz!
        /// </summary>
        public FileNotProvidedException() : base("Lütfen bir resim dosyası giriniz!")
        {
        }
    }
}
