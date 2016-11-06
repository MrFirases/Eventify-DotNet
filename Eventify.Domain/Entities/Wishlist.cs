using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Wishlist
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public Nullable<System.DateTime> dateAdding { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual User user { get; set; }
    }
}
