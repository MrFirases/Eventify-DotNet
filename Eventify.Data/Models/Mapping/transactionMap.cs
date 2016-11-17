using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class transactionMap : EntityTypeConfiguration<Transaction>
    {
        public transactionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.token)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("transaction");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.token).HasColumnName("token");
            this.Property(t => t.reservation_id).HasColumnName("reservation_id");

            // Relationships
            this.HasOptional(t => t.reservation)
                .WithMany(t => t.transactions)
                .HasForeignKey(d => d.reservation_id);

        }
    }
}
