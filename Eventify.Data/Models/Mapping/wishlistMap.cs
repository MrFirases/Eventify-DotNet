using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class wishlistMap : EntityTypeConfiguration<Wishlist>
    {
        public wishlistMap()
        {
            // Primary Key
            this.HasKey(t => new { t.eventId, t.userId });

            // Properties
            this.Property(t => t.eventId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.userId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("wishlist", "eventify");
            this.Property(t => t.eventId).HasColumnName("eventId");
            this.Property(t => t.userId).HasColumnName("userId");
            this.Property(t => t.dateAdding).HasColumnName("dateAdding");

            // Relationships
            this.HasRequired(t => t.myevent)
                .WithMany(t => t.wishlists)
                .HasForeignKey(d => d.eventId);
            this.HasRequired(t => t.user)
                .WithMany(t => t.wishlists)
                .HasForeignKey(d => d.userId);

        }
    }
}
