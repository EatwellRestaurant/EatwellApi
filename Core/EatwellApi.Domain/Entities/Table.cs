using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class Table : BaseEntity
    {
        public int BranchId { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public byte Capacity { get; set; }



        public Branch Branch { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
