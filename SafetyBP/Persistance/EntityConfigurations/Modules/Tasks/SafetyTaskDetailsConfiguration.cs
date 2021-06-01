using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyTaskDetailsConfiguration : IEntityTypeConfiguration<SafetyTaskDetails>
    {
        public void Configure(EntityTypeBuilder<SafetyTaskDetails> builder)
        {
            builder.ToTable(TableNamesConstants.TASKSDETAILS);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Code).HasMaxLength(200);
            builder.Property(prop => prop.Name).HasMaxLength(1000);
            builder.Property(prop => prop.Comments).HasMaxLength(2048);
            builder.Property(prop => prop.StartDateTime);
            builder.Property(prop => prop.EndDateTime);
            builder.Property(prop => prop.IsComplete);
            builder.Property(prop => prop.Priority);
            builder.Property(prop => prop.Url);
            builder.Property(prop => prop.Files);
            builder.HasMany(prop => prop.CheckList).WithOne(prop => prop.TaskDetail);
        }
    }
}
