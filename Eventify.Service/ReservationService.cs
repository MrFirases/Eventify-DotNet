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


        public int countReservationByPaymentMethod(string method)
        {
            return itw.getRepository<Reservation>().GetMany(reservation => reservation.paymentMethod == method).Count();
        }

        public IEnumerable<Reservation> AmountByMonth()
        {
            return itw.getRepository<Reservation>().GetMany(
                    reservation => reservation.reservationState == "CONFIRMED" && reservation.timerState == "FINISHED")
                .GroupBy(reservation => reservation.reservationDate.Value.Month)
                .Select(
                    grouping =>
                        new Reservation()
                        {
                            id = grouping.Key,
                            amount = grouping.Sum(reservation => reservation.amount)
                        });
        }

        public IEnumerable<Reservation> AmountByYear()
        {
            return itw.getRepository<Reservation>().GetMany(
                    reservation => reservation.reservationState == "CONFIRMED" && reservation.timerState == "FINISHED")
                .GroupBy(reservation => reservation.reservationDate.Value.Year)
                .Select(
                    grouping =>
                        new Reservation()
                        {
                            id = grouping.Key,
                            amount = grouping.Sum(reservation => reservation.amount)
                        });
        }

        public IEnumerable<Reservation> reservationsByPaymentMethod()
        {
            return itw.getRepository<Reservation>().GetMany(reservation => reservation.timerState == "FINISHED")
                .GroupBy(reservation => reservation.paymentMethod)
                .Select(grouping => new Reservation()
                {
                    paymentMethod = grouping.Key,
                    id = grouping.Count()
                });
        }

        public IEnumerable<Reservation> reservationsByTimerState()
        {
            return itw.getRepository<Reservation>().GetMany()
                .GroupBy(reservation => reservation.timerState)
                .Select(grouping => new Reservation()
                {
                    timerState = grouping.Key,
                    id = grouping.Count()
                });
        }

        public IEnumerable<Reservation> reservationsbyState()
        {
            return itw.getRepository<Reservation>().GetMany(reservation => reservation.timerState == "FINISHED")
                .GroupBy(reservation => reservation.reservationState)
                .Select(
                    grouping =>
                        new Reservation()
                        {
                            reservationState = grouping.Key,
                            id = grouping.Count()
                        });
        }

        public IEnumerable<Reservation> reservationsByEvents()
        {
            return  itw.getRepository<Reservation>().GetMany(
                    reservation => reservation.timerState == "FINISHED" && reservation.reservationState == "CONFIRMED").ToList()
                .GroupBy(reservation => reservation.ticket.myevent.title)
                .Select(
                    grouping => new Reservation()
                    {
                        reservationState = grouping.Key,
                        amount = grouping.Sum(reservation => reservation.amount)
                    }
                );
        }

        public IEnumerable<Reservation> reservationsByTicketsEvents()
        {
            return itw.getRepository<Reservation>().GetMany(
                    reservation => reservation.timerState == "FINISHED" && reservation.reservationState == "CONFIRMED").ToList()
                .GroupBy(reservation => new { reservation.ticket.myevent.title, reservation.ticket.typeTicket })
                .Select(
                    grouping => new Reservation()
                    {
                        reservationState = grouping.Key.title,
                        paymentMethod = grouping.Key.typeTicket,
                        amount = grouping.Sum(reservation => reservation.amount)
                    }
                );

        }
    }
}
