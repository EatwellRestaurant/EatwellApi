using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.MealCategory
{
    public class MealCategoryUpsertDto : IDto
    {
        public IFormFile Image { get; set; }

        public string Name { get; set; }
    } 
}
