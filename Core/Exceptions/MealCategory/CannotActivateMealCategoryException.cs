using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.MealCategory
{
    public class CannotActivateMealCategoryException : BadRequestBaseException
    {
        /// <summary>
        /// Bu menü adı, başka bir menüde kullanıldığı için aktif hale getirilemez.
        /// </summary>
        public CannotActivateMealCategoryException() : base("Bu menü adı, başka bir menüde kullanıldığı için aktif hale getirilemez.")
        {
        }
    }
}
