using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Rate
    {
        public int idEvent { get; set; }
        public int idUser { get; set; }
        public float note { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual User user { get; set; }
    }
}
