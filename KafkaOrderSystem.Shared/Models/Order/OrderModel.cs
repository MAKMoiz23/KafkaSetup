namespace KafkaOrderSystem.Shared.Models.Order
{
    public class OrderModel
    {
        public long OrderNo { get; set; }
        public int NoOfproducts { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
