using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class notificationMap : EntityTypeConfiguration<Notification>
    {
        public notificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.notificationDescription)
                .HasMaxLength(255);

            this.Property(t => t.notificationTitle)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("notification");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.notificationDate).HasColumnName("notificationDate");
            this.Property(t => t.notificationDescription).HasColumnName("notificationDescription");
            this.Property(t => t.notificationTitle).HasColumnName("notificationTitle");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.notifications)
                .HasForeignKey(d => d.user_id);

        }
    }
}
