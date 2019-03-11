using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class AanwezigheidConfiguration : IEntityTypeConfiguration<Aanwezigheid> {
        public void Configure(EntityTypeBuilder<Aanwezigheid> builder) {
            #region Table
            builder.ToTable("Aanwezigheid");
            #endregion

            #region Primary Key
            builder.HasKey(a => a.Id);
            #endregion

            #region Relaties
            builder.HasOne(t => t.Sessie)
                .WithMany(t => t.Aanwezigheden)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Properties
            builder.Property(a => a.Lid)
                .IsRequired();

            builder.Property(a => a.Sessie)
                .IsRequired();
            #endregion
        }
    }
}
