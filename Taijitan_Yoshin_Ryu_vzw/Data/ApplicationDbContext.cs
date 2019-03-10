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
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Formule> formules { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
        }
    }
}
