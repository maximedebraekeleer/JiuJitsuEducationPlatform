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
        //public DbSet<Aanwezigheid> aanwezigheden { get; set; }
        public DbSet<Formule> Formules { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Trainingsdag> Trainingsdagen { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            //Inheritance
            builder.Entity<Lid>();
            builder.Entity<Lesgever>();

            //Configurations
            //builder.ApplyConfiguration(new AanwezigheidConfiguration());
            builder.ApplyConfiguration(new FormuleConfiguration());
            builder.ApplyConfiguration(new FormuleTrainingsdagConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new LesgeverConfiguration());
            builder.ApplyConfiguration(new LidConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new TrainingsdagConfiguration());
        }
    }
}
