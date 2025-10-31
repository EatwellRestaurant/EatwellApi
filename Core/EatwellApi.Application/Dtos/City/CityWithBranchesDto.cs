using EatwellApi.Application.Dtos.Branch;

namespace EatwellApi.Application.Dtos.City
{
    public class CityWithBranchesDto : CityDto
    {
        public List<BranchDto> Branches { get; set; }
    }
}
