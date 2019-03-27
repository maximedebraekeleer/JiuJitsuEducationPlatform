using Taijitan_Yoshin_Ryu_vzw.Data.Mappers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class ApplicationDbContext : IdentityDbContext {
        #region DbSets
        public DbSet<Aanwezigheid> aanwezigheden { get; set; }
        public DbSet<Formule> Formules { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Trainingsmoment> Trainingsmomenten { get; set; }
        public DbSet<Graad> Graden { get; set; }
        public DbSet<LesmateriaalThema> LesmateriaalThemas { get; set; }
        public DbSet<Lesmateriaal> Lesmaterialen { get; set; }        
        public DbSet<Commentaar> Commentaren { get; set; }
        public DbSet<Logging> Loggings { get; set; }
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
            builder.ApplyConfiguration(new AanwezigheidConfiguration());
            builder.ApplyConfiguration(new FormuleConfiguration());
            builder.ApplyConfiguration(new FormuleTrainingsmomentConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new LesgeverConfiguration());
            builder.ApplyConfiguration(new LidConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new TrainingsmomentConfiguration());

            builder.ApplyConfiguration(new GraadConfiguration());
            builder.ApplyConfiguration(new LesmateriaalThemaConfiguration());
            builder.ApplyConfiguration(new GraadLesmateriaalThemaConfiguration());
            builder.ApplyConfiguration(new LesmateriaalConfiguration());
            builder.ApplyConfiguration(new CommentaarConfiguration());

            //Ignores
            builder.Ignore<Beheerder>();
        }
    }
}
