using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class LidConfiguration : IEntityTypeConfiguration<Lid> {
        public void Configure(EntityTypeBuilder<Lid> builder) {
            #region Relaties
            builder.HasOne(t => t.Formule)
                .WithMany(t => t.Leden);

            builder.HasOne(t => t.Graad)
                .WithMany();
            #endregion
        }
    }
}
