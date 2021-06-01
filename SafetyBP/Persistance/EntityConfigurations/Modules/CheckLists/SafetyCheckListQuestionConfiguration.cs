using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyCheckListQuestionConfiguration : IEntityTypeConfiguration<SafetyCheckListQuestion>
    {
        public void Configure(EntityTypeBuilder<SafetyCheckListQuestion> builder)
        {
            builder.ToTable(TableNamesConstants.CHECKLISTS_QUESTIONS_2);
            builder.Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Code);
            builder.Property(prop => prop.RelatedId);
            builder.Property(prop => prop.Type);
            builder.Property(prop => prop.IsAlert);
            builder.Property(prop => prop.PhotoRequired);
            builder.Property(prop => prop.IsCritica);
            builder.Property(prop => prop.Name);
            builder.Property(prop => prop.Value);
            builder.Property(prop => prop.IsPendingToSyncronize);
            builder.Property(prop => prop.DoesNotApply);
            builder.HasMany(prop => prop.NegativeValues).WithOne(prop => prop.Question);
            builder.Ignore(prop => prop.ValueOptions);
            
        }
    }
}
