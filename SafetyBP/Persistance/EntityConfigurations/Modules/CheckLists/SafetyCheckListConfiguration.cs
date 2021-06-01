using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyCheckListConfiguration : IEntityTypeConfiguration<SafetyCheckList>
    {
        public void Configure(EntityTypeBuilder<SafetyCheckList> builder)
        {
            builder.ToTable(TableNamesConstants.CHECKLISTS2);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Sector).HasMaxLength(1000).IsRequired();
            builder.HasMany(prop => prop.Details).WithOne(prop => prop.CheckList);
        }
    }
}
