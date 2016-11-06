using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eventify.Data.Models.Mapping
{
    public class answerMap : EntityTypeConfiguration<Answer>
    {
        public answerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idAttribut, t.idUser });

            // Properties
            this.Property(t => t.idAttribut)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.answer1)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("answer", "eventify");
            this.Property(t => t.idAttribut).HasColumnName("idAttribut");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.answer1).HasColumnName("answer");
            this.Property(t => t.dateAnswer).HasColumnName("dateAnswer");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.idUser);
            this.HasRequired(t => t.attribut)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.idAttribut);

        }
    }
}
