using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class User
    {
        public User()
        {
            this.answers = new List<Answer>();
            this.comments = new List<Comment>();
            this.favorites = new List<Favorite>();
            this.messages = new List<Message>();
            this.notifications = new List<Notification>();
            this.organizations = new List<Organization>();
            this.organizers = new List<Organizer>();
            this.rates = new List<Rate>();
            this.referrelusers = new List<Referreluser>();
            this.referrelusers1 = new List<Referreluser>();
            this.reports = new List<Report>();
            this.reservations = new List<Reservation>();
            this.wishlists = new List<Wishlist>();
        }

        public int id { get; set; }
        public string accountState { get; set; }
        public string confirmationToken { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int loyaltyPoint { get; set; }
        public string numTel { get; set; }
        public string password { get; set; }
        public string profileImage { get; set; }
        public string username { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
        public virtual ICollection<Favorite> favorites { get; set; }
        public virtual ICollection<Message> messages { get; set; }
        public virtual ICollection<Notification> notifications { get; set; }
        public virtual ICollection<Organization> organizations { get; set; }
        public virtual ICollection<Organizer> organizers { get; set; }
        public virtual ICollection<Rate> rates { get; set; }
        public virtual ICollection<Referreluser> referrelusers { get; set; }
        public virtual ICollection<Referreluser> referrelusers1 { get; set; }
        public virtual ICollection<Report> reports { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
        public virtual ICollection<Wishlist> wishlists { get; set; }
    }
}
