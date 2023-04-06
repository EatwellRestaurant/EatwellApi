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
        public IResult Add(Reservation reservation)
        {
            var result = BusinessRules.Run(
                CheckIfReservation(reservation.ReservationDate, reservation.ReservationTime));

            if (!result.Success)
            {
                return result;
            }

            _reservationDal.Add(reservation);
            return new SuccessResult(ReservationMessages.ReservationAdded);
        }

        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            return new SuccessResult(ReservationMessages.ReservationDeleted);
        }

        public IDataResult<Reservation> Get(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(r => r.Id == id), ReservationMessages.ReservationWasBrought);
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(), ReservationMessages.ReservationsListed);
        }


        [ValidationAspect(typeof(ReservationValidator))]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult(ReservationMessages.ReservationUpdated);
        }




        //Business Codes
        private IResult CheckIfReservation(DateTime reservationDate, string reservationTime)
        {
            var resultDate = _reservationDal.GetAll(r => r.ReservationDate == reservationDate);

            if (resultDate.Count > 0)
            {
                var resultTime = _reservationDal.GetAll(r => r.ReservationTime == reservationTime).Any();

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
