using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class ControlObjectsHardwareConfiguration : IEntityTypeConfiguration<ControlObjectsHardware>
    {
        public void Configure(EntityTypeBuilder<ControlObjectsHardware> builder)
        {
            builder.ToTable(TableNamesConstants.CONTROL_OBJECT_HARDWARE);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.QrId).IsRequired();
            builder.Property(prop => prop.Name).HasMaxLength(2000).IsRequired();
            builder.HasMany(prop => prop.Sectors).WithOne(prop => prop.Hardware);
        }
    }
}
