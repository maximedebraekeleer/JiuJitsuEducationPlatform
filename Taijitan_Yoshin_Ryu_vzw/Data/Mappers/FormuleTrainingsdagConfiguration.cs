using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class FormuleTrainingsdagConfiguration : IEntityTypeConfiguration<FormuleTrainingsdag> {
        public void Configure(EntityTypeBuilder<FormuleTrainingsdag> builder) {
            #region Table
            builder.ToTable("Formule_Trainingsdag");
            #endregion

            #region Key
            builder.HasKey(t => new { t.Formule_Id, t.Trainingsdag_Id });
            #endregion

            #region Relaties
            builder.HasOne(t => t.Formule)
                    .WithMany(t => t.FormuleTrainingsdagen)
                    .HasForeignKey(t => t.Formule_Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Trainingsdag)
                    .WithMany(t => t.FormuleTrainingsdagen)
                    .HasForeignKey(t => t.Trainingsdag_Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
