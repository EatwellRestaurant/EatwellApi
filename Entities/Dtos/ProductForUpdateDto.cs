using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductForUpdateDto
    {
        public int? MealCategoryId { get; set; }

        public string ProductName { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
