using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class mediumMap : EntityTypeConfiguration<medium>
    {
        public mediumMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pathMedia)
                .HasMaxLength(255);

            this.Property(t => t.typeMedia)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("media", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.mediaDate).HasColumnName("mediaDate");
            this.Property(t => t.pathMedia).HasColumnName("pathMedia");
            this.Property(t => t.typeMedia).HasColumnName("typeMedia");
            this.Property(t => t.event_id).HasColumnName("event_id");

            // Relationships
            this.HasOptional(t => t.myevent)
                .WithMany(t => t.media)
                .HasForeignKey(d => d.event_id);

        }
    }
}
