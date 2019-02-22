using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class LesgroepConfiguration : IEntityTypeConfiguration<Lesgroep> {
        public void Configure(EntityTypeBuilder<Lesgroep> builder) {
            #region Table
            builder.ToTable("Lesgroep");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Groepsnaam);
            #endregion

            #region Properties
            builder.Property(t => t.Groepsnaam)
                    .HasMaxLength(45)
                    .IsRequired();
            #endregion
        }
    }
}
