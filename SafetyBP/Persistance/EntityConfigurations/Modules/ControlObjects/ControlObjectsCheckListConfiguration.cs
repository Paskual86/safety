using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class ControlObjectsCheckListConfiguration : IEntityTypeConfiguration<ControlObjectsCheckList>
    {
        public void Configure(EntityTypeBuilder<ControlObjectsCheckList> builder)
        {
            builder.ToTable(TableNamesConstants.CONTROL_OBJECT_CHECKLIST);
            builder.HasKey(prop => new { prop.Id, prop.SurveyId });
            builder.Property(prop => prop.SurveyId).IsRequired();
            builder.Property(prop => prop.Type).IsRequired();
            builder.Property(prop => prop.IsAlert).IsRequired();
            builder.Property(prop => prop.IsPhotoRequired).IsRequired();
            builder.Property(prop => prop.IsCritica).IsRequired();
            builder.Property(prop => prop.QuestionDescription).HasMaxLength(5000).IsRequired();
            builder.Property(prop => prop.Answer).HasMaxLength(5000);
        }
    }
}
