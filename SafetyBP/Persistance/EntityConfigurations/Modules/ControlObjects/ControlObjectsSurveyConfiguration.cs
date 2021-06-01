using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class ControlObjectsSurveyConfiguration : IEntityTypeConfiguration<ControlObjectsSurvey>
    {
        public void Configure(EntityTypeBuilder<ControlObjectsSurvey> builder)
        {
            builder.ToTable(TableNamesConstants.CONTROL_OBJECT_SURVEYS);
            builder.HasKey(prop => new { prop.Id, prop.SectorId } );
            builder.Property(prop => prop.SectorId).IsRequired();
            builder.Property(prop => prop.HardwareQrId).IsRequired();
            builder.Property(prop => prop.HardwareId).IsRequired();
            builder.Property(prop => prop.HardwareName).HasMaxLength(2000).IsRequired();
            builder.Property(prop => prop.Date).HasMaxLength(20).IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(2000).IsRequired();
            builder.Property(prop => prop.ObjectId).IsRequired();
            builder.Property(prop => prop.ObjectName).HasMaxLength(2000).IsRequired();
            builder.Property(prop => prop.IsVisible).IsRequired();
            builder.Property(prop => prop.IsActive);
            builder.Property(prop => prop.IsFinalize);
            builder.HasMany(prop => prop.Questions).WithOne(prop => prop.Survey);
            builder.HasMany(prop => prop.CheckLists).WithOne(prop => prop.Survey);
        }
    }
}
