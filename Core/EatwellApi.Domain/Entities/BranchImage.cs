using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class BranchImage : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string? ImagePath { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }




        public Branch Branch { get; set; }

    }
}
