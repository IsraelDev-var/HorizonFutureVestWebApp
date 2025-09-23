using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;


namespace Persistence.EntityConfigurations
{
    public class CountryEntityConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            #region basic Configuration
                builder.HasKey(x => x.Id);
                builder.ToTable("Coutries");
            #endregion

            #region Property configuration
            builder.Property(u => u.Name).IsRequired().HasMaxLength(200);
            builder.Property(u => u.ISOCode).IsRequired().HasMaxLength(50);
            #endregion

            #region relationships
            builder.HasMany<IndicatorsByCountry>(c => c.Indicators)
                .WithOne(ic => ic.Country)
                .HasForeignKey(ic => ic.CountryId)
                .OnDelete(DeleteBehavior.Restrict); // si tiene indicadores asociado no se eliminara
            #endregion

        }
    }
}
