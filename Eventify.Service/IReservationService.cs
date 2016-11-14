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
        IEnumerable<Reservation> getAmountByEvent(Myevent myevent);
        IEnumerable<Reservation> getAmountByEvents();
        int countReservationByPaymentMethod(string method);

    }
}
