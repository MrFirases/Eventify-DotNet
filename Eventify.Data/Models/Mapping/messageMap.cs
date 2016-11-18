using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class messageMap : EntityTypeConfiguration<Message>
    {
        public messageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.message1)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("message");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.claim).HasColumnName("claim");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.message1).HasColumnName("message");
            this.Property(t => t.sended).HasColumnName("sended");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.messages)
                .HasForeignKey(d => d.user_id);

        }
    }
}
