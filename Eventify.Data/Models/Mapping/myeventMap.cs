using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class myeventMap : EntityTypeConfiguration<Myevent>
    {
        public myeventMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.eventState)
                .HasMaxLength(255);

            this.Property(t => t.eventType)
                .HasMaxLength(255);

            this.Property(t => t.facebookLink)
                .HasMaxLength(255);

            this.Property(t => t.theme)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.twitterLink)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("myevent");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.endTime).HasColumnName("endTime");
            this.Property(t => t.eventState).HasColumnName("eventState");
            this.Property(t => t.eventType).HasColumnName("eventType");
            this.Property(t => t.facebookLink).HasColumnName("facebookLink");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.nbViews).HasColumnName("nbViews");
            this.Property(t => t.placeNumber).HasColumnName("placeNumber");
            this.Property(t => t.startTime).HasColumnName("startTime");
            this.Property(t => t.theme).HasColumnName("theme");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.twitterLink).HasColumnName("twitterLink");
            this.Property(t => t.category_id).HasColumnName("category_id");
            this.Property(t => t.organization_id).HasColumnName("organization_id");

            // Relationships
            this.HasOptional(t => t.category)
                .WithMany(t => t.myevents)
                .HasForeignKey(d => d.category_id);
            this.HasOptional(t => t.organization)
                .WithMany(t => t.myevents)
                .HasForeignKey(d => d.organization_id);

        }
    }
}
