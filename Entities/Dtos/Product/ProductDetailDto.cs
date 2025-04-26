using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductDetailDto : EntityDetailDtoForAdmin
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
