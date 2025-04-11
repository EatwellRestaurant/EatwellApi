using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MealCategory : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }




        public ICollection<Product> Products { get; set; }

    }
}
