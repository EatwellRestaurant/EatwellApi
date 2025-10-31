using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class LeaveType : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }




        public ICollection<Permission> Permissions { get; set; }

    }
}
