using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class LidLesgroepConfiguration : IEntityTypeConfiguration<LidLesgroep> {
        public void Configure(EntityTypeBuilder<LidLesgroep> builder) {
            #region Table
            builder.ToTable("Lid_Lesgroep");
            #endregion

            #region Key
            builder.HasKey(t => new { t.Lid_Id, t.Lesgroep_Groepsnaam });
            #endregion

            #region Relations
            builder.HasOne(t => t.Lid)
                    .WithMany(t => t.LidLesgroepen)
                    .HasForeignKey(t => t.Lid_Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Lesgroep)
                    .WithMany(t => t.LidLesgroepen)
                    .HasForeignKey(t => t.Lesgroep_Groepsnaam)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
