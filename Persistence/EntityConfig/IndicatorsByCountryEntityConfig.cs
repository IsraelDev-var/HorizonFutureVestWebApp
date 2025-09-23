using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;


namespace Persistence.EntityConfigurations
{
    public class IndicatorsByCountryEntityConfig : IEntityTypeConfiguration<IndicatorsByCountry>
    {
        

        public void Configure(EntityTypeBuilder<IndicatorsByCountry> builder)
        {
            #region basic Configuration
            builder.HasKey(x => new {x.CountryId, x.MacroindicatorId});
            builder.ToTable("IndicadorePorPaises");
            #endregion

            #region Property configuration
            builder.Property(u => u.Value).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Year).IsRequired().HasMaxLength(50);
            #endregion


        }
    }
}
