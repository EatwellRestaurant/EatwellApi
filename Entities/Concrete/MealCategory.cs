﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MealCategory : BaseEntity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }
        
        public string ImageName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DeactivationDate { get; set; }



        public ICollection<Product> Products { get; set; }

    }
}
