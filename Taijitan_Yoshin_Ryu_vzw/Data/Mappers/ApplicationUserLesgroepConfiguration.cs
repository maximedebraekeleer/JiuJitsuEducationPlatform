using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class ApplicationUserLesgroepConfiguration : IEntityTypeConfiguration<ApplicationUserLesgroep> {
        public void Configure(EntityTypeBuilder<ApplicationUserLesgroep> builder) {
            #region Table
            builder.ToTable("ApplicationUser_Lesgroep");
            #endregion

            #region Key
            builder.HasKey(t => new { t.ApplicationUser_Id, t.Lesgroep_Groepsnaam });
            #endregion

            #region Relations
            builder.HasOne(t => t.ApplicationUser)
                    .WithMany(t => t.ApplicationUserLesgroepen)
                    .HasForeignKey(t => t.ApplicationUser_Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Lesgroep)
                    .WithMany(t => t.ApplicationUserLesgroepen)
                    .HasForeignKey(t => t.Lesgroep_Groepsnaam)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
