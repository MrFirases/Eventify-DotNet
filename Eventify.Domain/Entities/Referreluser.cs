using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Referreluser
    {
        public int idUserReferral { get; set; }
        public int idUserReferred { get; set; }
        public Nullable<System.DateTime> dateInvitation { get; set; }
        public string stateInvitation { get; set; }
        public virtual User user { get; set; }
        public virtual User user1 { get; set; }
    }
}
