using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class reportMap : EntityTypeConfiguration<Report>
    {
        public reportMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            this.Property(t => t.subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("report", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.reportDate).HasColumnName("reportDate");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.subject).HasColumnName("subject");
            this.Property(t => t.event_id).HasColumnName("event_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.userWhoReport_id).HasColumnName("userWhoReport_id");

            // Relationships
            this.HasOptional(t => t.myevent)
                .WithMany(t => t.reports)
                .HasForeignKey(d => d.event_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.reports)
                .HasForeignKey(d => d.userWhoReport_id);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.reports1)
                .HasForeignKey(d => d.user_id);

        }
    }
}
