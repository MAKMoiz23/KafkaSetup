using KafkaOrderSystem.Producer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KafkaOrderSystem.Producer.EntitiesConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.ProductName)
                .IsRequired();
            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
