using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class organizerMap : EntityTypeConfiguration<Organizer>
    {
        public organizerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idOrganization, t.idUser });

            // Properties
            this.Property(t => t.idOrganization)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.state)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("organizer");
            this.Property(t => t.idOrganization).HasColumnName("idOrganization");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.state).HasColumnName("state");

            // Relationships
            this.HasRequired(t => t.organization)
                .WithMany(t => t.organizers)
                .HasForeignKey(d => d.idOrganization);
            this.HasRequired(t => t.user)
                .WithMany(t => t.organizers)
                .HasForeignKey(d => d.idUser);

        }
    }
}
