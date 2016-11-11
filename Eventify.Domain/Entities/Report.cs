using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Report
    {
        public int id { get; set; }
        public string content { get; set; }
        public int state { get; set; }
        public string subject { get; set; }
        public Nullable<int> event_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual User user { get; set; }
    }
}
