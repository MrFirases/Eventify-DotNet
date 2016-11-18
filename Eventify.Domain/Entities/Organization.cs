using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Eventify.Data.Models
{
    public partial class Organization
    {
        public Organization()
        {
            this.myevents = new List<Myevent>();
            this.organizers = new List<Organizer>();
        }

        public int id { get; set; }
        [JsonProperty(".created")]

        public Nullable<System.DateTime> creationDate { get; set; }
        public string organizationName { get; set; }
        public string organizationType { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual ICollection<Myevent> myevents { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<Organizer> organizers { get; set; }
    }
}
