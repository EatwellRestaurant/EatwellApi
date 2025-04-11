using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.MealCategory
{
    public class MealCategoryDetailDto : EntityDetailDtoForAdmin
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
