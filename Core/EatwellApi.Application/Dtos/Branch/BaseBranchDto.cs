using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Branch
{
    public class BaseBranchDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
