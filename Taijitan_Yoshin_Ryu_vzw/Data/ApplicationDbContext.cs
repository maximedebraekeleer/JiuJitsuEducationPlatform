using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Data.Mappers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class ApplicationDbContext : IdentityDbContext {
        #region DbSets
        //Identity
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Lesgroep> Lesgroepen { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LesgroepConfiguration());
            builder.ApplyConfiguration(new ApplicationUserLesgroepConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new SessieLesgroepConfiguration());
        }
    }
}
