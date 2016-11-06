using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Organizer
    {
        public Organizer()
        {
            this.tasks = new List<Task>();
        }

        public int idOrganization { get; set; }
        public int idUser { get; set; }
        public string state { get; set; }
        public virtual Organization organization { get; set; }
        public virtual ICollection<Task> tasks { get; set; }
        public virtual User user { get; set; }
    }
}
