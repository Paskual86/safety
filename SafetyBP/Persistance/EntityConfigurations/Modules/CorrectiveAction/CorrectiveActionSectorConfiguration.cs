using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;

namespace SafetyBP.Persistance.EntityConfigurations.Modules.CorrectiveAction
{
    public class CorrectiveActionSectorConfiguration : IEntityTypeConfiguration<CorrectiveActionSector>
    {
        public void Configure(EntityTypeBuilder<CorrectiveActionSector> builder)
        {
            builder.ToTable(TableNamesConstants.CORRECTIVE_ACTIONS_SECTOR);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).HasMaxLength(1000);
            builder.HasMany(hm => hm.Topics).WithOne(wo => wo.Sector);
        }
    }
}
