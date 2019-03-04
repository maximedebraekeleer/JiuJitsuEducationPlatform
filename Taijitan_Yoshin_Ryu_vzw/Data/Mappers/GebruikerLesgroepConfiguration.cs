using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class GebruikerLesgroepConfiguration : IEntityTypeConfiguration<GebruikerLesgroep> {
        public void Configure(EntityTypeBuilder<GebruikerLesgroep> builder) {
            #region Table
            builder.ToTable("ApplicationUser_Lesgroep");
            #endregion

            #region Key
            builder.HasKey(t => new { t.Gebruiker_email, t.Lesgroep_Groepsnaam });
            #endregion

            #region Relations
            builder.HasOne(t => t.Gebruiker)
                    .WithMany(t => t.GebruikerLesgroepen)
                    .HasForeignKey(t => t.Gebruiker_email)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Lesgroep)
                    .WithMany(t => t.GebruikerLesgroepen)
                    .HasForeignKey(t => t.Lesgroep_Groepsnaam)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
