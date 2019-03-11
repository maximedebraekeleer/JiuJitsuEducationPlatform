using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class SessieConfiguration : IEntityTypeConfiguration<Sessie> {
        public void Configure(EntityTypeBuilder<Sessie> builder) {
            #region Table
            builder.ToTable("Sessie");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Relaties
            builder.HasMany(t => t.Aanwezigheden)
                .WithOne(t => t.Sessie)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Lesgever)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Properties
            builder.Property(t => t.BeginDatumEnTijd)
                .IsRequired();

            builder.Property(t => t.EindDatumEnTijd)
                .IsRequired();

            //builder.Property(t => t.Lesgever)
            //    .IsRequired();
            #endregion
        }
    }
}
