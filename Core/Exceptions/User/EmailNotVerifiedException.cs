using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class EmailNotVerifiedException : BadRequestBaseException
    {
        /// <summary>
        /// E-posta adresiniz henüz doğrulanmamış. Lütfen e-posta kutunuzu kontrol edin ve doğrulamayı tamamlayın.
        /// </summary>
        public EmailNotVerifiedException() : base("E-posta adresiniz henüz doğrulanmamış. Lütfen e-posta kutunuzu kontrol edin ve doğrulamayı tamamlayın.")
        {
        }
    }
}
