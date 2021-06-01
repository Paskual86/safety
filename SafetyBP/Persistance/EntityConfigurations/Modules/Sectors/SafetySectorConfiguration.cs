using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetySectorConfiguration : IEntityTypeConfiguration<SafetySector>
    {
        public void Configure(EntityTypeBuilder<SafetySector> builder)
        {
            builder.ToTable(TableNamesConstants.SECTORS);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Sector).HasMaxLength(1000).IsRequired();
        }
    }

}
