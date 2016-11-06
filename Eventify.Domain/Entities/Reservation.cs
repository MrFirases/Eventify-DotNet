using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            this.transactions = new List<Transaction>();
        }

        public int id { get; set; }
        public float amount { get; set; }
        public string paymentMethod { get; set; }
        public Nullable<System.DateTime> reservationDate { get; set; }
        public string reservationState { get; set; }
        public string timerState { get; set; }
        public Nullable<int> ticket_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual User user { get; set; }
        public virtual Ticket ticket { get; set; }
        public virtual ICollection<Transaction> transactions { get; set; }
    }
}
