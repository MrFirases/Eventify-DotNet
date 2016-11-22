using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public interface IReservationService : IMyServiceGeneric<Reservation>
    {
        float getOurAmount();
        double getAllAmount();
        int countReservationByPaymentMethod(string method);
        IEnumerable<Reservation> AmountByMonth();
        IEnumerable<Reservation> AmountByYear();
        IEnumerable<Reservation> reservationsByPaymentMethod();
        IEnumerable<Reservation> reservationsByTimerState();
        IEnumerable<Reservation> reservationsbyState();
        IEnumerable<Reservation> reservationsByEvents();
        IEnumerable<Reservation> reservationsByTicketsEvents();
    }
}
