using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            this.reservations = new List<Reservation>();
        }

        public int id { get; set; }
        public string backgroundImage { get; set; }
        public int nbTickets { get; set; }
        public float priceTicket { get; set; }
        public string typeTicket { get; set; }
        public Nullable<int> event_id { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
    }
}
