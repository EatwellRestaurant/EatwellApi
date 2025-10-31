using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

         
         
        public ICollection<Branch> Branches { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
