using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int MealCategoryId { get; set; }

        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }

        public byte Order { get; set; }

        public string Name { get; set; }
        
        public string ImagePath { get; set; }
        
        public string ImageName { get; set; }
        
        public decimal Price { get; set; }

        public DateTime? DeactivationDate { get; set; }



        public MealCategory MealCategory { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
