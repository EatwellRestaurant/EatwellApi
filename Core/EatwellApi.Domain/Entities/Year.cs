using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class Year : BaseEntity
    {
        public string Name { get; set; }



        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Month> Months { get; set; }
    }
}
