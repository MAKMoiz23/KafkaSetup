namespace KafkaOrderSystem.Shared.Models.Order
{
    public class OrderModel
    {
        public Guid MyProperty { get; set; } = Guid.NewGuid();
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
