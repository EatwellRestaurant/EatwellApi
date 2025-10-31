using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchUpsertDto : IDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string? WebSite { get; set; }

        public string? Facebook { get; set; }

        public string? Instagram { get; set; }

        public string? Twitter { get; set; }

        public string? Gmail { get; set; }
    }
}
