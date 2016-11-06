using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Task
    {
        public int id { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public string taskDescription { get; set; }
        public int taskStatus { get; set; }
        public string taskTitle { get; set; }
        public Nullable<int> event_id { get; set; }
        public Nullable<int> organizer_idOrganization { get; set; }
        public Nullable<int> organizer_idUser { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual Organizer organizer { get; set; }
    }
}
