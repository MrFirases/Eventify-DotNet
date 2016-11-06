using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class taskMap : EntityTypeConfiguration<Task>
    {
        public taskMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.taskDescription)
                .HasMaxLength(255);

            this.Property(t => t.taskTitle)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("task", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.taskDescription).HasColumnName("taskDescription");
            this.Property(t => t.taskStatus).HasColumnName("taskStatus");
            this.Property(t => t.taskTitle).HasColumnName("taskTitle");
            this.Property(t => t.event_id).HasColumnName("event_id");
            this.Property(t => t.organizer_idOrganization).HasColumnName("organizer_idOrganization");
            this.Property(t => t.organizer_idUser).HasColumnName("organizer_idUser");

            // Relationships
            this.HasOptional(t => t.myevent)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.event_id);
            this.HasOptional(t => t.organizer)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => new { d.organizer_idOrganization, d.organizer_idUser });

        }
    }
}
