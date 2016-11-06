using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Notification
    {
        public int id { get; set; }
        public Nullable<System.DateTime> notificationDate { get; set; }
        public string notificationDescription { get; set; }
        public string notificationTitle { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual User user { get; set; }
    }
}
