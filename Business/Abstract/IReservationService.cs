using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        Task<IDataResult<List<Reservation>>> GetAll();
        Task<IDataResult<Reservation?>> Get(int id);
        Task<IResult> Add(Reservation reservation);
        IResult Delete(Reservation reservation);
        IResult Update(Reservation reservation);
    }
}
