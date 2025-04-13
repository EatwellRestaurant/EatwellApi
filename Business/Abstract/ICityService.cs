using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.City;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService : IService<City>
    {
        Task<DataResponse<List<CityWithBranchCountDto>>> GetAll();
        Task<DataResponse<CityWithBranchesDto>> Get(int cityId);
    }
}
