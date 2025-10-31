using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class Shift : IEntity
    {
        public int Id { get; set; }

        public string Day { get; set; }




        public ICollection<ShiftDay> ShiftDays { get; set; }
    }
}
