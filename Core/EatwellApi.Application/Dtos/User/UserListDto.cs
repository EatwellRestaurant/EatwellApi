using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.User
{
    public class UserListDto : IDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int OrderCount { get; set; }

        public decimal TotalSpentAmount { get; set; }

        public bool? Verification { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
