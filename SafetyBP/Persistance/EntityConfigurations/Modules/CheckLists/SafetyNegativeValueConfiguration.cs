using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetyNegativeValueConfiguration : IEntityTypeConfiguration<SafetyCheckListNegativeValue>
    {
        public void Configure(EntityTypeBuilder<SafetyCheckListNegativeValue> builder)
        {
            builder.ToTable(TableNamesConstants.CHECKLISTS_QUESTIONS_NEGATIVE_VALUES);
            //builder.Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.QuestionId);
            builder.Property(prop => prop.Value);
            builder.Property(prop => prop.ValueType);

        }
    }
}
