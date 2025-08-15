using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public int MealCategoryId { get; set; }

        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }

        public byte Order { get; set; }

        public string Name { get; set; }
        
        public string ImagePath { get; set; }
        
        public string ImageName { get; set; }
        
        public decimal Price { get; set; }

        public DateTime? DeactivationDate { get; set; }



        public MealCategory MealCategory { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
