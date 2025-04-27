using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductInsertDto : ProductUpsertDto
    {
        public int MealCategoryId { get; set; }

        public IFormFile Image { get; set; }
    }
}
