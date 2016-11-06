using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class reservationMap : EntityTypeConfiguration<Reservation>
    {
        public reservationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.paymentMethod)
                .HasMaxLength(255);

            this.Property(t => t.reservationState)
                .HasMaxLength(255);

            this.Property(t => t.timerState)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reservation", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.paymentMethod).HasColumnName("paymentMethod");
            this.Property(t => t.reservationDate).HasColumnName("reservationDate");
            this.Property(t => t.reservationState).HasColumnName("reservationState");
            this.Property(t => t.timerState).HasColumnName("timerState");
            this.Property(t => t.ticket_id).HasColumnName("ticket_id");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.user_id);
            this.HasOptional(t => t.ticket)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.ticket_id);

        }
    }
}
