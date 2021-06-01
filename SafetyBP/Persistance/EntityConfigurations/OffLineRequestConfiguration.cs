using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Entities;

namespace SafetyBP.Persistance.EntityConfigurations
{
    public class OffLineRequestConfiguration : IEntityTypeConfiguration<OffLineRequest>
    {
        public void Configure(EntityTypeBuilder<OffLineRequest> builder)
        {
            builder.ToTable(TableNamesConstants.OFFLINEREQUEST);
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
            builder.Property(prop => prop.Request).HasMaxLength(1000000);
            builder.Property(prop => prop.Url).HasMaxLength(1000);
            builder.Property(prop => prop.UserId).HasMaxLength(100);
            builder.Property(prop => prop.RequestId);
            builder.Property(prop => prop.OperationId);
            builder.Property(prop => prop.OrderId);
        }
    }
}
