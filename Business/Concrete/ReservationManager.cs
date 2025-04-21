using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Reservation;
using Core.ResponseModels;
using Core.Utilities.Business;
using Core.Utilities.Email;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        readonly IReservationDal _reservationDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IReservationDal reservationDal, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _reservationDal = reservationDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [ValidationAspect(typeof(ReservationUpsertDtoValidator))]
        public async Task<CreateSuccessResponse> Add(ReservationUpsertDto upsertDto)
        {
            await CheckIfReservation(upsertDto.ReservationDate);
            
            await _reservationDal.AddAsync(_mapper.Map<Reservation>(upsertDto));
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(ReservationMessages.ReservationAdded);
        }

        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Remove(reservation);
            return new SuccessResult(ReservationMessages.ReservationDeleted);
        }

        public async Task<IDataResult<Reservation?>> Get(int id)
        {
            return new SuccessDataResult<Reservation?>(await _reservationDal.GetAsync(r => r.Id == id), ReservationMessages.ReservationWasBrought);
        }

        public async Task<IDataResult<List<Reservation>>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(await _reservationDal.GetAllAsync(), ReservationMessages.ReservationsListed);
        }


        [ValidationAspect(typeof(ReservationUpsertDtoValidator))]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(ReservationMessages.ReservationUpdated);
        }




        //Business Codes
        private async Task CheckIfReservation(DateTime reservationDate)
        {
            if (await _reservationDal.AnyAsync(r => r.ReservationDate == reservationDate && r.IsDeleted))
                throw new ReservationAlreadyExistsException();
        }
    }
}
