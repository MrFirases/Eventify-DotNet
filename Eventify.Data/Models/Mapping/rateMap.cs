using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class rateMap : EntityTypeConfiguration<Rate>
    {
        public rateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idEvent, t.idUser });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("rate", "eventify");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.note).HasColumnName("note");

            // Relationships
            this.HasRequired(t => t.myevent)
                .WithMany(t => t.rates)
                .HasForeignKey(d => d.idEvent);
            this.HasRequired(t => t.user)
                .WithMany(t => t.rates)
                .HasForeignKey(d => d.idUser);

        }
    }
}
