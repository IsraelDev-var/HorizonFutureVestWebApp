using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;


namespace Persistence.EntityConfig
{
    public class MacroindicatorSimulationEntityConfig : IEntityTypeConfiguration<MacroindicatorSimulation>
    {
        public void Configure(EntityTypeBuilder<MacroindicatorSimulation> builder)
        {
            #region Basic Configuration
                builder.HasKey(m => m.Id);
                builder.ToTable("SimulacionMacroIndicador");
            #endregion
            #region Property configuration
            builder.Property(u => u.SimulationWeight).IsRequired();
            #endregion


        }
    }
}
