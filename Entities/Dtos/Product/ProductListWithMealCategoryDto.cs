using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductListWithMealCategoryDto : ProductAdminListDto
    {
        public int MealCategoryId { get; set; }

        public string MealCategoryName { get; set; }
    }
}
