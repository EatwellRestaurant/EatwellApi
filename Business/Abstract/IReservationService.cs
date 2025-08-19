using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using Entities.Filters;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService : IService<Reservation>
    {
        Task<PaginationResponse<ReservationListDto>> GetAllForAdmin(int branchId, PaginationRequest paginationRequest, ReservationFilter filter);

        Task<DataResponse<ReservationDetailDto>> Get(int reservationId);
        
        Task<CreateSuccessResponse> Add(ReservationUpsertDto upsertDto);
        
        IResult Delete(Reservation reservation);
        
        IResult Update(Reservation reservation);

        Task<DataResponse<int>> GetReservationCount(int? branchId);
    }
}
