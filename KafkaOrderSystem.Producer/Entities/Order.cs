namespace KafkaOrderSystem.Producer.Entities
{
    public class Order : BaseEntity
    {
        public long OrderNo { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; } = [];
    }
}
