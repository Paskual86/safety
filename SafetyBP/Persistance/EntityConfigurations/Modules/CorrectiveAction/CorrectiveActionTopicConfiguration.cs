using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;

namespace SafetyBP.Persistance.EntityConfigurations.Modules.CorrectiveAction
{
    public class CorrectiveActionTopicConfiguration : IEntityTypeConfiguration<CorrectiveActionTopic>
    {
        public void Configure(EntityTypeBuilder<CorrectiveActionTopic> builder)
        {
            builder.ToTable(TableNamesConstants.CORRECTIVE_ACTIONS_TOPICS);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.SectorId);
            builder.Property(prop => prop.Reason).HasMaxLength(5000);
            builder.Property(prop => prop.DueDate);
            builder.HasMany(hm => hm.Tasks).WithOne(wo => wo.Topic);
        }
    }
}
