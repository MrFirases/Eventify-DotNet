using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class favoriteMap : EntityTypeConfiguration<Favorite>
    {
        public favoriteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.categoryId, t.userId });

            // Properties
            this.Property(t => t.categoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.userId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("favorite", "eventify");
            this.Property(t => t.categoryId).HasColumnName("categoryId");
            this.Property(t => t.userId).HasColumnName("userId");
            this.Property(t => t.priority).HasColumnName("priority");

            // Relationships
            this.HasRequired(t => t.category)
                .WithMany(t => t.favorites)
                .HasForeignKey(d => d.categoryId);
            this.HasRequired(t => t.user)
                .WithMany(t => t.favorites)
                .HasForeignKey(d => d.userId);

        }
    }
}
