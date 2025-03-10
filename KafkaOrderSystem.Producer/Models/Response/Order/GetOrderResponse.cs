namespace KafkaOrderSystem.Producer.Models.Response.Order
{
    public class GetOrderResponse
    {
        public Guid Id { get; set; }
        public string? OrderNo { get; set; }
        public IEnumerable<GetOrderItemResponse>? Items { get; set; }
    }

    public class GetOrderItemResponse
    {
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
