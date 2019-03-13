using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class TrainingsmomentConfiguration : IEntityTypeConfiguration<Trainingsmoment> {
        public void Configure(EntityTypeBuilder<Trainingsmoment> builder) {
            #region Table
            builder.ToTable("Trainingsmoment");
            #endregion

            #region Primary Key
            builder.HasKey(t => t.Id);
            #endregion
        }
    }
}
