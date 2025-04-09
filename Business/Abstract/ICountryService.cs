using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<List<Country>>> GetAll();
        Task<IDataResult<Country?>> Get(int id);
        Task<IResult> Add(Country country);
        IResult Delete(Country country);
        IResult Update(Country country);
    }
}
