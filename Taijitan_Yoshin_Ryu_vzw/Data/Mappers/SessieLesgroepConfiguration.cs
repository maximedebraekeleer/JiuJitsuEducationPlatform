using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class SessieLesgroepConfiguration : IEntityTypeConfiguration<SessieLesgroep> {
        public void Configure(EntityTypeBuilder<SessieLesgroep> builder) {
            #region Table
            builder.ToTable("Sessie_Lesgroep");
            #endregion

            #region Key
            builder.HasKey(t => new { t.Sessie_Id, t.Lesgroep_Groepsnaam });
            #endregion

            #region Relations
            builder.HasOne(t => t.Sessie)
                    .WithMany(t => t.SessieLesgroepen)
                    .HasForeignKey(t => t.Sessie_Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Lesgroep)
                    .WithMany(t => t.SessieLesgroepen)
                    .HasForeignKey(t => t.Lesgroep_Groepsnaam)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
