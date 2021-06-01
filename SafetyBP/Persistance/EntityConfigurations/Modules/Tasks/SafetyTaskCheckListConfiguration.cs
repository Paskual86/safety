using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyTaskCheckListConfiguration : IEntityTypeConfiguration<SafetyTaskCheckList>
    {
        public void Configure(EntityTypeBuilder<SafetyTaskCheckList> builder)
        {
            builder.ToTable(TableNamesConstants.TASKSDETAILSCHECKLIST);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).HasMaxLength(1000);
            builder.Property(prop => prop.Status);
            builder.Property(prop => prop.IsPendingToSync);
        }
    }
}
