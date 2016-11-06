using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Comment
    {
        public int idEvent { get; set; }
        public int idUser { get; set; }
        public string contain { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual User user { get; set; }
    }
}
