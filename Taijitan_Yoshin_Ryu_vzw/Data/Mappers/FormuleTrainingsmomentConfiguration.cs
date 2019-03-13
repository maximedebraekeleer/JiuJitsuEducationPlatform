using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class FormuleTrainingsmomentConfiguration : IEntityTypeConfiguration<FormuleTrainingsmoment> {
        public void Configure(EntityTypeBuilder<FormuleTrainingsmoment> builder) {
            #region Table
            builder.ToTable("Formule_Trainingsmoment");
            #endregion

            #region Keys
            builder.HasKey(bc => new { bc.FormuleId, bc.TrainingsmomentId });
            #endregion

            #region Relaties
            builder.HasOne(bc => bc.Formule)
                .WithMany(b => b.FormuleTrainingsmomenten)
                .HasForeignKey(bc => bc.FormuleId);

            builder.HasOne(bc => bc.Trainingsmoment)
                .WithMany(c => c.FormuleTrainingsmomenten)
                .HasForeignKey(bc => bc.TrainingsmomentId);
            #endregion
        }
    }
}
