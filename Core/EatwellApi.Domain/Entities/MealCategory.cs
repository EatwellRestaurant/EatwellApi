using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class MealCategory : BaseEntity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DeactivationDate { get; set; }



        public ICollection<Product> Products { get; set; }

    }
}
