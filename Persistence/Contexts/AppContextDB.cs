

using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

using System.Reflection;

namespace Persistence.Contexts
{
    public class AppContextDB : DbContext
    {
        public AppContextDB(DbContextOptions<AppContextDB> options): base (options) { }


        // Configuracion de las entidades
        public DbSet<Country> Counties { get; set; }

        public DbSet<Macroindicator> Macroindicators { get; set; }
        public DbSet<IndicatorsByCountry> IndicatorsByCountries { get; set; }
        public DbSet<ReteOfReturn> RateOfReturns { get; set; }
        //public DbSet<RankingResult> RankingResults { get; set; } Esta tabla no se almacenara
        public DbSet<MacroindicatorSimulation> MacroindicatorSimulations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.ApplyConfiguration(new CountryEntityConfig());
            //modelBuilder.ApplyConfiguration(new IndicatorsByCountryEntityConfig());
            //modelBuilder.ApplyConfiguration(new MacroindicatorEntityConfig());
            //modelBuilder.ApplyConfiguration(new MacroindicatorSimulationEntityConfig());
            //modelBuilder.ApplyConfiguration(new ReteOfReturnEntityConfig());

        } 

        
        

        
    }
}
