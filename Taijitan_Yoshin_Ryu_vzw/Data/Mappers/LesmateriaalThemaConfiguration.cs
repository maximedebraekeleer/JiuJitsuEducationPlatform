using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class LesmateriaalThemaConfiguration : IEntityTypeConfiguration<LesmateriaalThema>
    {
        public void Configure(EntityTypeBuilder<LesmateriaalThema> builder)
        {
            #region Table
            builder.ToTable("LesmateriaalThema");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Relaties
            builder.HasMany(t => t.Lesmaterialen)
                .WithOne(l => l.LesmateriaalThema);
            #endregion
        }
    }
}
