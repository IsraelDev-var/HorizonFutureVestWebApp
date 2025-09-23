
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.EntityConfig
{
    public class ReteOfReturnEntityConfig : IEntityTypeConfiguration<ReteOfReturn>
    {
       

        public void Configure(EntityTypeBuilder<ReteOfReturn> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("TasaRetono");
            #endregion

            #region Property configuration
            builder.Property(r =>  r.MinimunRete).IsRequired();
            builder.Property(r => r.MaximunRete).IsRequired();
            #endregion
        }
    }
}
