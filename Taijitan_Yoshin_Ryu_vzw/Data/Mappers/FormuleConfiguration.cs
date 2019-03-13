using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class FormuleConfiguration : IEntityTypeConfiguration<Formule> {
        public void Configure(EntityTypeBuilder<Formule> builder) {
            #region Table
            builder.ToTable("Formule");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Relaties
            builder.HasMany(t => t.Leden)
                .WithOne(t => t.Formule);
            #endregion
        }
    }
}
