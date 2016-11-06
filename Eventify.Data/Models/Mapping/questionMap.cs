using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class questionMap : EntityTypeConfiguration<Question>
    {
        public questionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.questionCategory)
                .HasMaxLength(255);

            this.Property(t => t.questionDescription)
                .HasMaxLength(255);

            this.Property(t => t.questionType)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("question", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.order).HasColumnName("order");
            this.Property(t => t.questionCategory).HasColumnName("questionCategory");
            this.Property(t => t.questionDate).HasColumnName("questionDate");
            this.Property(t => t.questionDescription).HasColumnName("questionDescription");
            this.Property(t => t.questionType).HasColumnName("questionType");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.event_id).HasColumnName("event_id");

            // Relationships
            this.HasOptional(t => t.myevent)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.event_id);

        }
    }
}
