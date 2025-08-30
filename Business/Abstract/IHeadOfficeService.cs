using Core.ResponseModels;
using Entities.Dtos.HeadOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadOfficeService
    {
        Task<DataResponse<HeadOfficeDto>> GetAsync();
    }
}
