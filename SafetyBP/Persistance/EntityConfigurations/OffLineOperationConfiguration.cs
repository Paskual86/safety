using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Entities;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class OffLineOperationConfiguration : IEntityTypeConfiguration<OffLineOperation>
    {
        public void Configure(EntityTypeBuilder<OffLineOperation> builder)
        {
            builder.ToTable(TableNamesConstants.OFFLINOPERATION);
            builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Module).HasMaxLength(100);
        }
    }
}
