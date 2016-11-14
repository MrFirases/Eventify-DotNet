using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<User>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.accountState)
                .HasMaxLength(255);

            this.Property(t => t.confirmationToken)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numTel)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.profileImage)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "eventify");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.accountState).HasColumnName("accountState");
            this.Property(t => t.confirmationToken).HasColumnName("confirmationToken");
            this.Property(t => t.creationDate).HasColumnName("creationDate");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.loyaltyPoint).HasColumnName("loyaltyPoint");
            this.Property(t => t.numTel).HasColumnName("numTel");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.profileImage).HasColumnName("profileImage");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.banState).HasColumnName("banState");
        }
    }
}
