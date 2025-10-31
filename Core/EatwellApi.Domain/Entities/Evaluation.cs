using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class Evaluation : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }

         


        public User User { get; set; }
    }
}
