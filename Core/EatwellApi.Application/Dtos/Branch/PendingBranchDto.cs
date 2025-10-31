using EatwellApi.Domain.Enums.Branch;

namespace EatwellApi.Application.Dtos.Branch
{
    public class PendingBranchDto : BaseBranchDto
    {
        public BranchStatusEnum Status { get; set; }

        public string StatusName { get; set; }

        public DateTime? EstimatedOpeningDate { get; set; }
    }
}
