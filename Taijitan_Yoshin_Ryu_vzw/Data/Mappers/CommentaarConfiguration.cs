using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers
{
    public class CommentaarConfiguration : IEntityTypeConfiguration<Commentaar>
    {
        public void Configure(EntityTypeBuilder<Commentaar> builder)
        {
            #region Table
            builder.ToTable("Commentaar");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion

            #region Relations
            builder.HasOne(c => c.Lesmateriaal)
                .WithMany(lm => lm.Commentaren);

            builder.HasOne(c => c.Lid);
            #endregion
        }
    }
}
