using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductDetailDto : ProductListDto
    {
        public string ImagePath { get; set; }
    }
}
