namespace KafkaOrderSystem.Producer.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }

        public IEnumerable<OrderItems> OrderItems { get; set; } = [];
    }
}
