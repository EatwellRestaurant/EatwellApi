namespace EatwellApi.Application.Dtos.Branch
{
    public class MonthlySalesDto
    {
        public byte MonthId { get; set; }

        public string MonthName { get; set; }

        public decimal Sales { get; set; }
    }
}
