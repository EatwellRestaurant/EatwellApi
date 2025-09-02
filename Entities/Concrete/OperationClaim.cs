using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }




        public ICollection<User> Users { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
