namespace EatwellApi.Application.Dtos.Branch
{
    public class BranchListWithCityDto : BranchListDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

    }
}
