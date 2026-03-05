namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchSalesDto : BranchLookupDto
    {
        public List<MonthlySalesDto> Sales { get; set; }
    }
}
