using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchOverviewDto : IDto
    {
        public ActiveBranchDto ActiveBranchDto { get; set; }

        public List<PendingBranchDto> PendingBranchDtos { get; set; }

    }
}
