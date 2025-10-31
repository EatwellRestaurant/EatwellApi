using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.PageContent
{
    public class PageContentListDto : IDto
    {
        public int Id { get; internal set; }

        public byte SectionId { get; set; }

        public string SectionName { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
