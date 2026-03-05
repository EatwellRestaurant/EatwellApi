using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Abstractions.Services.City
{
    public interface ICityService
    {
        Task<DataResponse<List<CityLookupDto>>> GetLookupAsync();

        Task<PaginationResponse<CityListDto>> GetAllAsync(PaginationRequest request);
    }
}
