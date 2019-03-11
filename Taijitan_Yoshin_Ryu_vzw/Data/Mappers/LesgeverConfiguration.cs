using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Mappers {
    public class LesgeverConfiguration : IEntityTypeConfiguration<Lesgever> {
        public void Configure(EntityTypeBuilder<Lesgever> builder) {
            #region Properties
            //TODO
            #endregion
        }
    }
}
