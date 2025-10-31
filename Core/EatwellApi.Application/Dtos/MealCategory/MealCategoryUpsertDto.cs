using EatwellApi.Domain.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Dtos.MealCategory
{
    public class MealCategoryUpsertDto : IDto
    {
        public IFormFile? Image { get; set; }

        public string Name { get; set; }
    }
}
