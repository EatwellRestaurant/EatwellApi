﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.Extensions;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.Exceptions.Reservation;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using Entities.Filters;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        readonly IReservationDal _reservationDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly IBranchService _branchService;
        readonly ITableService _tableService;

        public ReservationManager(
            IReservationDal reservationDal,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IBranchService branchService,
            ITableService tableService)
        {
            _reservationDal = reservationDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _branchService = branchService;
            _tableService = tableService;
        }



        [ValidationAspect(typeof(ReservationUpsertDtoValidator))]
        public async Task<CreateSuccessResponse> Add(ReservationUpsertDto upsertDto)
        {
            int tableId = await GetAvailableTableIdAsync(upsertDto.ReservationDate, upsertDto.BranchId, upsertDto.PersonCount);

            Reservation reservation = _mapper.Map<Reservation>(upsertDto);

            reservation.TableId = tableId;

            await _reservationDal.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }


        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Remove(reservation);
            return new SuccessResult(ReservationMessages.ReservationDeleted);
        }



        public async Task<DataResponse<ReservationDetailDto>> Get(int reservationId)
        {
            Reservation? reservation = await _reservationDal
                .Where(r => r.Id == reservationId && !r.IsDeleted)
                .Include(r => r.Table)
                .AsNoTracking()
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Rezervasyon");


            return new DataResponse<ReservationDetailDto>
                           (_mapper.Map<ReservationDetailDto>(reservation),
                           CommonMessages.EntityFetch);
        }



        [SecuredOperation("admin", Priority = 1)]
        public async Task<PaginationResponse<ReservationListDto>> GetAllForAdmin(int branchId, PaginationRequest paginationRequest, ReservationFilter filter)
        {
            IQueryable<Reservation> query = _reservationDal
                .GetAllQueryable(r => r.BranchId == branchId)
                .FilterByFullName(filter.FullName)
                .FilterByTableId(filter.TableId)
                .FilterByDate(filter.DateRangeFilter);

            List<ReservationListDto> reservationListDtos = _mapper.Map<List<ReservationListDto>>
                (await query.Include(r => r.Table)
                .OrderByDescending(r => r.CreateDate)
                .ApplyPagination(paginationRequest)
                .ToListAsync());

            return new PaginationResponse<ReservationListDto>(reservationListDtos, paginationRequest, await query.CountAsync());
        }


        [ValidationAspect(typeof(ReservationUpsertDtoValidator))]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(ReservationMessages.ReservationUpdated);
        }




        #region BusinessRules

        private async Task<int> GetAvailableTableIdAsync(DateTime reservationDate, int branchId, int personCount)
        {
            if (!await _branchService.AnyAsync(b => b.Id == branchId && !b.IsDeleted))
                throw new EntityNotFoundException("Şube");


            List<Table> tables = await _tableService
                .Where(t => t.BranchId == branchId && t.Capacity >= personCount)
                .Include(t => t.Reservations)
                .AsNoTracking()
                .ToListAsync();


            if (!tables.Any())
                throw new NoAvailableTableException();


            Table? table = tables.Where(t => !t.Reservations.Any(r => r.ReservationDate == reservationDate))
                .OrderBy(t => t.Capacity)
                .FirstOrDefault() ??
                throw new NoAvailableTableException();


            return table.Id;
        }

        #endregion
    }
}
