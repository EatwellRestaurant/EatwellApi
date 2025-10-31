using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums;

namespace EatwellApi.Domain.Entities
{
    public class PageContent : IEntity
    { 
        public int Id { get; set; }

        public PageEnum Page { get; set; }

        public SectionEnum Section { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        public string? ImageName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }


    }
}
