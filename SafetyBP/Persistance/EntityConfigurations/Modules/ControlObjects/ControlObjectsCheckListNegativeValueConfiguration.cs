using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class ControlObjectsCheckListNegativeValueConfiguration : IEntityTypeConfiguration<ControlObjectsCheckListNegativeValue>
    {
        public void Configure(EntityTypeBuilder<ControlObjectsCheckListNegativeValue> builder)
        {
            builder.ToTable(TableNamesConstants.CONTROL_OBJECT_NEGATIVEVALUES);
            //builder.Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.CheckListId);
            builder.Property(prop => prop.Value);
            builder.Property(prop => prop.ValueType);

        }
    }
}
