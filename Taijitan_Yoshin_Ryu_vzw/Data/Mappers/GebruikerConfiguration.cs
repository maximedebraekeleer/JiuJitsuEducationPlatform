using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            #region Table
            builder.ToTable("Gebruiker");
            #endregion

            #region Primary Key
            builder.HasKey(g => g.Email);
            #endregion

            #region Properties
            //EmailOuders niet verplicht
            //Telefoonnummer niet verplicht

            builder.Property(t => t.Naam)
                   .IsRequired();

            builder.Property(t => t.Voornaam)
                   .IsRequired();

            builder.Property(t => t.Geslacht)
                   .IsRequired();

            builder.Property(t => t.GeboorteDatum)
                   .IsRequired();

            builder.Property(t => t.GeboorteLand)
                   .IsRequired();

            builder.Property(t => t.GeboorteStad)
                   .IsRequired();

            builder.Property(t => t.Straat)
                   .IsRequired();

            builder.Property(t => t.HuisNummer)
                   .IsRequired();

            builder.Property(t => t.Gemeente)
                   .IsRequired();

            builder.Property(t => t.Postcode)
                   .IsRequired();

            builder.Property(t => t.GsmNummer)
                   .IsRequired();

            builder.Property(t => t.RijksregisterNummer)
                   .IsRequired();

            builder.Property(t => t.InschrijvingsDatum)
                   .IsRequired();

            builder.Property(t => t.InfoClubAangelegenheden)
                   .IsRequired();

            builder.Property(t => t.InfoFederaleAangelegenheden)
                   .IsRequired();
            #endregion

        }
    }
}
