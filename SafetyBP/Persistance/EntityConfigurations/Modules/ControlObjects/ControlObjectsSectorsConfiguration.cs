using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class ControlObjectsSectorsConfiguration : IEntityTypeConfiguration<ControlObjectsSector>
    {
        public void Configure(EntityTypeBuilder<ControlObjectsSector> builder)
        {
            builder.ToTable(TableNamesConstants.CONTROL_OBJECT_SECTORS);
            builder.HasKey(prop => new { prop.Id, prop.HardwareId });
            builder.Property(prop => prop.HardwareId).IsRequired();
            builder.Property(prop => prop.SurveyId).IsRequired();
            builder.Property(prop => prop.HardwareQrId).IsRequired();
            builder.Property(prop => prop.HardwareName).HasMaxLength(2000).IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(2000).IsRequired();
            builder.Property(prop => prop.Place).HasMaxLength(5000).IsRequired();
            builder.HasMany(prop => prop.Surveys).WithOne(prop => prop.Sector);
        }
    }
}
