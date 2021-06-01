using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyCheckListDetailConfiguration : IEntityTypeConfiguration<SafetyCheckListDetail>
    {
        public void Configure(EntityTypeBuilder<SafetyCheckListDetail> builder)
        {
            builder.ToTable(TableNamesConstants.CHECKLISTS_DETAILS_2);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).HasMaxLength(1000).IsRequired();
            builder.Property(prop => prop.DueDateTime);
            builder.Property(prop => prop.IsPendingToSyncronize);
            builder.Property(prop => prop.Complete);
            builder.HasMany(prop => prop.Questions).WithOne(prop => prop.CheckList);
        }
    }
}
