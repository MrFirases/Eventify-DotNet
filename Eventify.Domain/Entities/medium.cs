using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class medium
    {
        public int id { get; set; }
        public Nullable<System.DateTime> mediaDate { get; set; }
        public string pathMedia { get; set; }
        public string typeMedia { get; set; }
        public Nullable<int> event_id { get; set; }
        public virtual Myevent myevent { get; set; }
    }
}
