using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class LesmateriaalConfiguration : IEntityTypeConfiguration<Lesmateriaal>
    {
        public void Configure(EntityTypeBuilder<Lesmateriaal> builder)
        {
            #region Table
            builder.ToTable("Lesmateriaal");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Relations
            builder.HasOne(t => t.Graad)
                .WithMany();

            builder.HasOne(t => t.LesmateriaalThema)
                .WithMany(lt => lt.Lesmaterialen);
            #endregion
        }
    }
}
