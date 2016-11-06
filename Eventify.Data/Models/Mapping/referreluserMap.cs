using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class referreluserMap : EntityTypeConfiguration<Referreluser>
    {
        public referreluserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idUserReferral, t.idUserReferred });

            // Properties
            this.Property(t => t.idUserReferral)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUserReferred)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stateInvitation)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("referreluser", "eventify");
            this.Property(t => t.idUserReferral).HasColumnName("idUserReferral");
            this.Property(t => t.idUserReferred).HasColumnName("idUserReferred");
            this.Property(t => t.dateInvitation).HasColumnName("dateInvitation");
            this.Property(t => t.stateInvitation).HasColumnName("stateInvitation");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.referrelusers)
                .HasForeignKey(d => d.idUserReferred);
            this.HasRequired(t => t.user1)
                .WithMany(t => t.referrelusers1)
                .HasForeignKey(d => d.idUserReferral);

        }
    }
}
