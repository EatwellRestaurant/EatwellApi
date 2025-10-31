namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchListWithCityDto : BranchDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

    }
}
