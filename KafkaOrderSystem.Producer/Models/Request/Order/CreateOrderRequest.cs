namespace KafkaOrderSystem.Producer.Models.Request.Order
{
    public class CreateOrderRequest
    {
        public IEnumerable<CreateOrderItem>? Items { get; set; }
    }

    public class CreateOrderItem
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
