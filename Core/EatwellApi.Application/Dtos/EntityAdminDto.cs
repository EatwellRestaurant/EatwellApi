using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos
{
    public class EntityAdminDto : IDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}
