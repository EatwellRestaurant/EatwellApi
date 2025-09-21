using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Permission
{
    public class LeaveQuotaExceededException : BadRequestBaseException
    {
        /// <summary>
        /// Kullanmak istediğiniz izin günleriyle birlikte belirlenen izin süresini geçmiş oluyorsunuz.
        /// </summary>
        public LeaveQuotaExceededException() : base("Kullanmak istediğiniz izin günleriyle birlikte belirlenen izin süresini geçmiş oluyorsunuz!")
        {
        }
    }
}
