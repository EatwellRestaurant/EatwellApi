namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchSalesDto : BaseBranchDto
    {
        public List<MonthlySalesDto> Sales { get; set; }
    }
}
