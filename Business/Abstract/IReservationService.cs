using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        Task<PaginationResponse<ReservationListDto>> GetAllForAdmin(int branchId, PaginationRequest paginationRequest);

        Task<IDataResult<Reservation?>> Get(int id);
        
        Task<CreateSuccessResponse> Add(ReservationUpsertDto upsertDto);
        
        IResult Delete(Reservation reservation);
        
        IResult Update(Reservation reservation);
    }
}
