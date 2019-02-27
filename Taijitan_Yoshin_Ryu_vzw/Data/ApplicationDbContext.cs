using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taijitan_Yoshin_Ryu_vzw.Data.Mappers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class ApplicationDbContext : IdentityDbContext<Lid> {
        #region DbSets
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Lesgroep> Lesgroepen { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

           protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LesgroepConfiguration());
            builder.ApplyConfiguration(new LidLesgroepConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new SessieLesgroepConfiguration());



        }
    }
}
