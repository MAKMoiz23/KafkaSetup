using KafkaOrderSystem.Producer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KafkaOrderSystem.Producer.EntitiesConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(u => u.Id)
                .HasDefaultValueSql("gen_random_uuid()");
            
            builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order);

            builder.Property(o => o.OrderNo)
                .IsRequired();

            builder.Property(o => o.OrderNo)
                .ValueGeneratedOnAdd();
        }
    }
}
