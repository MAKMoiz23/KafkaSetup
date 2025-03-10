namespace KafkaOrderSystem.Producer.Errors.Orders
{
    public static class OrderErrors
    {
        public static readonly ApiResponse.Error InvalidOrder = new("OrderErrors.InvalidInput", "The given parametres for order processing is invalid.");
        public static readonly ApiResponse.Error OrderProcessingFailed = new("OrderErrors.OrderProcessingFailed", "Order processing failed.");
    }
}
