using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyTaskAdditionalDataConfiguration : IEntityTypeConfiguration<SafetyTaskAdditionalData>
    {
        public void Configure(EntityTypeBuilder<SafetyTaskAdditionalData> builder)
        {
            builder.ToTable(TableNamesConstants.TASKS2);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Photo);
            builder.Property(prop => prop.Comments).HasMaxLength(4028);
            builder.HasOne(prop => prop.Task).WithOne(prop => prop.AdditionalData);
        }
    }
}
