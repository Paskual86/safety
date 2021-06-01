using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class SafetySpontaneousDiversionConfiguration : IEntityTypeConfiguration<SafetySpontaneousDiversion>
    {
        public void Configure(EntityTypeBuilder<SafetySpontaneousDiversion> builder)
        {
            builder.ToTable(TableNamesConstants.SPONTANEOUSDIVERSION);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Comment).HasMaxLength(2000);
            builder.Property(prop => prop.Photo);
            builder.Property(prop => prop.Reason).HasMaxLength(2000);
            builder.Property(prop => prop.Risk);
            builder.Property(prop => prop.Synchronized);
        }
    }

}
