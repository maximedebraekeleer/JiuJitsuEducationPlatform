using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class LidConfiguration : IEntityTypeConfiguration<Lid> {
        public void Configure(EntityTypeBuilder<Lid> builder) {
            #region Table
            builder.ToTable("Lid");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Email);
            #endregion

            #region Properties
            builder.Property(t => t.Naam)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(t => t.Voornaam)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(t => t.GeboorteDatum)
                .IsRequired();

            builder.Property(t => t.Straat)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(t => t.HuisNummer)
                .IsRequired();

            builder.Property(t => t.Gemeente)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(t => t.Postcode)
                .IsRequired();

            builder.Property(t => t.TelefoonNummer)
                .HasColumnName("telefoon")
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(t => t.IsBeheerder)
                .IsRequired();

            builder.Property(t => t.IsLesgever)
                .IsRequired();
            #endregion
        }
    }
}
