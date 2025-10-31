using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos
{
    public class AdminStatusBaseEntityListDto : IDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
        
        public DateTime? DeactivationDate { get; set; }
    }
}
