using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Transaction
    {
        public int id { get; set; }
        public float amount { get; set; }
        public string token { get; set; }
        public Nullable<int> reservation_id { get; set; }
        public virtual Reservation reservation { get; set; }
    }
}
