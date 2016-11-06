using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Attribut
    {
        public Attribut()
        {
            this.answers = new List<Answer>();
        }

        public int id { get; set; }
        public string attributValue { get; set; }
        public bool duplicated { get; set; }
        public Nullable<int> questions_id { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public virtual Question question { get; set; }
    }
}
