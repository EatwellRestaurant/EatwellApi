using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class BranchEmployee : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string Degree { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImagePath { get; set; }
        public string Description { get; set; }




        public Branch Branch { get; set; }
    }
}
