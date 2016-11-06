using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Eventify.Data.Models.Mapping;

namespace Eventify.Data.Models
{
    public partial class eventifyContext : DbContext
    {
        static eventifyContext()
        {
            Database.SetInitializer<eventifyContext>(null);
        }

        public eventifyContext()
            : base("Name=eventifyContext")
        {
        }

        public DbSet<Answer> answers { get; set; }
        public DbSet<Attribut> attributs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Favorite> favorites { get; set; }
        public DbSet<medium> media { get; set; }
        public DbSet<Myevent> myevents { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Organizer> organizers { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Rate> rates { get; set; }
        public DbSet<Referreluser> referrelusers { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Task> tasks { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new answerMap());
            modelBuilder.Configurations.Add(new attributMap());
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new commentMap());
            modelBuilder.Configurations.Add(new favoriteMap());
            modelBuilder.Configurations.Add(new mediumMap());
            modelBuilder.Configurations.Add(new myeventMap());
            modelBuilder.Configurations.Add(new notificationMap());
            modelBuilder.Configurations.Add(new organizationMap());
            modelBuilder.Configurations.Add(new organizerMap());
            modelBuilder.Configurations.Add(new questionMap());
            modelBuilder.Configurations.Add(new rateMap());
            modelBuilder.Configurations.Add(new referreluserMap());
            modelBuilder.Configurations.Add(new reservationMap());
            modelBuilder.Configurations.Add(new taskMap());
            modelBuilder.Configurations.Add(new ticketMap());
            modelBuilder.Configurations.Add(new transactionMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new wishlistMap());
        }
    }
}
