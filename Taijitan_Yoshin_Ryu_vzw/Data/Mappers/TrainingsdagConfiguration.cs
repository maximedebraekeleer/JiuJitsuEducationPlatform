using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class TrainingsdagConfiguration : IEntityTypeConfiguration<Trainingsdag> {
        public void Configure(EntityTypeBuilder<Trainingsdag> builder) {
            #region Table
            builder.ToTable("Trainingsdag");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Properties
            builder.Property(t => t.DagNummer)
                .IsRequired();

            builder.Property(t => t.DagNaam)
                .IsRequired();

            builder.Property(t => t.BeginUur)
                .IsRequired();

            builder.Property(t => t.EindUur)
                .IsRequired();
            #endregion
        }
    }
}
