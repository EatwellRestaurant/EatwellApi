using EatwellApi.Domain.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Dtos.PageContent
{
    public class PageContentUpdateDto : IDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }
    }
}
