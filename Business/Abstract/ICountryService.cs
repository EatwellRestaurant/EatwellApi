using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        Task<DataResponse<List<AdminCountryListDto>>> GetAllForAdmin();

        Task<DataResponse<List<CountryDto>>> GetAll();

        Task<DataResponse<CountryDto>> Get(int countryId);

        Task<DataResponse<CountryDto>> GetForAdmin(int countryId);

        Task<SuccessResponse> SetActiveOrPassive(ActivateCountryIdsDto countryIdsDto);
    }
}
