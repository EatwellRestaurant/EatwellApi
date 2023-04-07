using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int? MealCategoryId { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public decimal Price { get; set; }

    }
}
