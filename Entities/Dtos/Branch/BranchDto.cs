using Core.Entities.Abstract;

namespace Entities.Dtos.Branch
{
    public class BranchDto : BaseBranchDto
    {
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
