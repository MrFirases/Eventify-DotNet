using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public class ReservationService :MyServiceGeneric<Reservation>,IReservationService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public ReservationService() : base(itw)
        {

        }


        public float getOurAmount()
        {

            return itw.getRepository<Reservation>()
                .GetMany(reservation => reservation.reservationState== "CONFIRMED" && reservation.timerState == "FINISHED")
                .Sum(reservation => reservation.amount) * 0.1f;
        }

        public double getAllAmount()
        {
            return itw.getRepository<Reservation>()
                .GetMany(reservation => reservation.reservationState == "CONFIRMED" && reservation.timerState == "FINISHED")
                .Sum(reservation => reservation.amount);
        }

        public IEnumerable<Reservation> getAmountByEvent(Myevent myevent)
        {
            return itw.getRepository<Reservation>().GetMany(reservation => reservation.ticket.event_id == myevent.id);
        }

        public IEnumerable<Reservation> getAmountByEvents()
        {
            throw new NotImplementedException();
        }

        public int countReservationByPaymentMethod(string method)
        {
            return itw.getRepository<Reservation>().GetMany(reservation => reservation.paymentMethod == method).Count();
        }
    }
}
