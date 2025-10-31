using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities.Common
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
