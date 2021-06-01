using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;

namespace SafetyBP.Persistance.EntityConfigurations.Modules.CorrectiveAction
{
    public class CorrectiveActionTaskConfiguration : IEntityTypeConfiguration<CorrectiveActionTask>
    {
        public void Configure(EntityTypeBuilder<CorrectiveActionTask> builder)
        {
            builder.ToTable(TableNamesConstants.CORRECTIVE_ACTIONS_TASKS);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.TopicId);
            builder.Property(prop => prop.Name).HasMaxLength(1000);
            builder.Property(prop => prop.Status);
        }
    }
}
