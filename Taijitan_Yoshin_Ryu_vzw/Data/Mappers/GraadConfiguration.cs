using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class GraadConfiguration : IEntityTypeConfiguration<Graad>
    {
        public void Configure(EntityTypeBuilder<Graad> builder)
        {
            #region Table
            builder.ToTable("Graad");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.GraadId);
            #endregion
        }
    }
}
