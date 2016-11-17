using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class categoryMap : EntityTypeConfiguration<Category>
    {
        public categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.categoryName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("category");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
        }
    }
}
