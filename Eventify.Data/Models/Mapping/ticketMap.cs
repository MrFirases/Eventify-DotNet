using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class ticketMap : EntityTypeConfiguration<Ticket>
    {
        public ticketMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.backgroundImage)
                .HasMaxLength(255);

            this.Property(t => t.typeTicket)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ticket", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.backgroundImage).HasColumnName("backgroundImage");
            this.Property(t => t.nbTickets).HasColumnName("nbTickets");
            this.Property(t => t.priceTicket).HasColumnName("priceTicket");
            this.Property(t => t.typeTicket).HasColumnName("typeTicket");
            this.Property(t => t.event_id).HasColumnName("event_id");

            // Relationships
            this.HasOptional(t => t.myevent)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.event_id);

        }
    }
}
