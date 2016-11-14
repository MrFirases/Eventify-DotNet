using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Message
    {
        public int id { get; set; }
        public bool claim { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string message1 { get; set; }
        public bool sended { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual User user { get; set; }
    }
}
