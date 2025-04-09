using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }


        [ValidationAspect(typeof(ReservationValidator))]
        public async Task<IResult> Add(Reservation reservation)
        {
            var result = BusinessRules.Run(
                await CheckIfReservation(reservation.ReservationDate, reservation.ReservationTime));

            if (!result.Success)
            {
                return result;
            }

            await _reservationDal.AddAsync(reservation);
            return new SuccessResult(ReservationMessages.ReservationAdded);
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


        [ValidationAspect(typeof(ReservationValidator))]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(ReservationMessages.ReservationUpdated);
        }




        //Business Codes
        private async Task<IResult> CheckIfReservation(DateTime reservationDate, string reservationTime)
        {
            var resultDate = await _reservationDal.GetAllAsync(r => r.ReservationDate == reservationDate);

            if (resultDate.Count > 0)
            {
                var resultTime = await _reservationDal.AnyAsync(r => r.ReservationTime == reservationTime);

                if (resultTime)
                {
                    return new ErrorResult(ReservationMessages.ReservationExists);
                }
                return new SuccessResult();
            }
            return new SuccessResult();
        }
    }
}
