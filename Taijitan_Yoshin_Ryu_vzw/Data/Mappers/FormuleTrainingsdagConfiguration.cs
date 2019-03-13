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

                builder.HasKey(bc => new { bc.FormuleId, bc.TrainingsdagId });

                builder.HasOne(bc => bc.Formule)
                .WithMany(b => b.FormuleTrainingsdagen)
                .HasForeignKey(bc => bc.FormuleId);

                builder.HasOne(bc => bc.Trainingsdag)
                .WithMany(c => c.FormuleTrainingsdagen)
                .HasForeignKey(bc => bc.TrainingsdagId);
        }
    }
}
