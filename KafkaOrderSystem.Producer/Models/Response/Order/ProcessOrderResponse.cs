namespace KafkaOrderSystem.Producer.Models.Response.Order
{
    public class ProcessOrderResponse
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
