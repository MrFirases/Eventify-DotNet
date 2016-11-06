using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Answer
    {
        public int idAttribut { get; set; }
        public int idUser { get; set; }
        public string answer1 { get; set; }
        public Nullable<System.DateTime> dateAnswer { get; set; }
        public virtual User user { get; set; }
        public virtual Attribut attribut { get; set; }
    }
}
