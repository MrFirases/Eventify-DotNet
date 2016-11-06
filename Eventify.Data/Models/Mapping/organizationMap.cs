using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class organizationMap : EntityTypeConfiguration<Organization>
    {
        public organizationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.organizationName)
                .HasMaxLength(255);

            this.Property(t => t.organizationType)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("organization", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.creationDate).HasColumnName("creationDate");
            this.Property(t => t.organizationName).HasColumnName("organizationName");
            this.Property(t => t.organizationType).HasColumnName("organizationType");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.organizations)
                .HasForeignKey(d => d.user_id);

        }
    }
}
