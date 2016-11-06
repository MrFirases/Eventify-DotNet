using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class commentMap : EntityTypeConfiguration<Comment>
    {
        public commentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idEvent, t.idUser });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.contain)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("comment", "eventify");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.contain).HasColumnName("contain");

            // Relationships
            this.HasRequired(t => t.myevent)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.idEvent);
            this.HasRequired(t => t.user)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.idUser);

        }
    }
}
