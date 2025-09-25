using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;


namespace Persistence.EntityConfig
{
    public class MacroindicatorEntityConfig : IEntityTypeConfiguration<Macroindicator>
    {
        public void Configure(EntityTypeBuilder<Macroindicator> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.ToTable("Macroindicador");
            #endregion

            #region Property configuration
            builder.Property(u => u.Name).IsRequired().HasMaxLength(200);
            builder.Property(u => u.HigherIsBetter).IsRequired();
            builder.Property(u => u.Weight).IsRequired().HasDefaultValue(0).HasPrecision(18,4);
            #endregion

            #region Relatioship
            builder.HasMany<MacroindicatorSimulation>(m => m.MacroindicatorSimulations)
                .WithOne(ms => ms.Macroindicator)
                .HasForeignKey(ms => ms.MacroindicatorId);

            builder.HasMany<IndicatorsByCountry>(i => i.Indicators)
                .WithOne(ms => ms.Macroindicator)
                .HasForeignKey(ms => ms.MacroindicatorId);

            #endregion

            //.OnDelete(DeleteBehavior.Cascade); // Si eliminas un Country, se eliminan sus indicadores
            //.OnDelete(DeleteBehavior.Restrict); // No permite eliminar Country si tiene indicadores
            //.OnDelete(DeleteBehavior.NoAction); // Igual que Restrict, pero sin chequeo en memoria
        }
    }
}
