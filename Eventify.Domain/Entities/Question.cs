using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Question
    {
        public Question()
        {
            this.attributs = new List<Attribut>();
        }

        public int id { get; set; }
        public Nullable<int> order { get; set; }
        public string questionCategory { get; set; }
        public Nullable<System.DateTime> questionDate { get; set; }
        public string questionDescription { get; set; }
        public string questionType { get; set; }
        public int status { get; set; }
        public Nullable<int> event_id { get; set; }
        public virtual ICollection<Attribut> attributs { get; set; }
        public virtual Myevent myevent { get; set; }
    }
}
