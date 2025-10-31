using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Branch
{
    public class ActiveBranchDto : IDto
    {
        public List<SalesBranchDto> SalesBranchDtos { get; set; }

        public List<NonSalesBranchDto> NonSalesBranchDtos { get; set; }

    }
}
