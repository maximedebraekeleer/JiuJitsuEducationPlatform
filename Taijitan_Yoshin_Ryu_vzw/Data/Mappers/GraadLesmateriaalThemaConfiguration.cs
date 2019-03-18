using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class GraadLesmateriaalThemaConfiguration : IEntityTypeConfiguration<GraadLesmateriaalThema>
    {
        public void Configure(EntityTypeBuilder<GraadLesmateriaalThema> builder)
        {
            #region Table
            builder.ToTable("Graad_LesmateriaalThema");
            #endregion

            #region Keys
            builder.HasKey(gl => new { gl.GraadId, gl.LesmateriaalThemaId });
            #endregion

            #region Relaties
            builder.HasOne(gl => gl.Graad)
                .WithMany(g => g.GraadLesmateriaalThemas)
                .HasForeignKey(gl => gl.GraadId);

            builder.HasOne(gl => gl.LesmateriaalThema)
                .WithMany(l => l.GraadLesmateriaalThemas)
                .HasForeignKey(gl => gl.LesmateriaalThemaId);
            #endregion
        }
    }
}
