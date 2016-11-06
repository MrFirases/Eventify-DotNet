using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class attributMap : EntityTypeConfiguration<Attribut>
    {
        public attributMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.attributValue)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("attribut", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.attributValue).HasColumnName("attributValue");
            this.Property(t => t.duplicated).HasColumnName("duplicated");
            this.Property(t => t.questions_id).HasColumnName("questions_id");

            // Relationships
            this.HasOptional(t => t.question)
                .WithMany(t => t.attributs)
                .HasForeignKey(d => d.questions_id);

        }
    }
}
