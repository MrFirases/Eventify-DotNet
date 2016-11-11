using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Myevent
    {
        public Myevent()
        {
            this.comments = new List<Comment>();
            this.rates = new List<Rate>();
            this.reports = new List<Report>();
            this.tickets = new List<Ticket>();
            this.mymedias = new List<Mymedia>();
            this.tasks = new List<Task>();
            this.questions = new List<Question>();
            this.wishlists = new List<Wishlist>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<System.DateTime> endTime { get; set; }
        public string eventState { get; set; }
        public string eventType { get; set; }
        public string facebookLink { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int nbViews { get; set; }
        public int placeNumber { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public string theme { get; set; }
        public string title { get; set; }
        public string twitterLink { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> organization_id { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
        public virtual ICollection<Rate> rates { get; set; }
        public virtual ICollection<Report> reports { get; set; }
        public virtual Organization organization { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }
        public virtual ICollection<Mymedia> mymedias { get; set; }
        public virtual ICollection<Task> tasks { get; set; }
        public virtual ICollection<Question> questions { get; set; }
        public virtual ICollection<Wishlist> wishlists { get; set; }
    }
}
