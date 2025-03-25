using System.ComponentModel.DataAnnotations.Schema;

namespace KafkaOrderSystem.Producer.Entities
{
    public class OrderItems : BaseEntity
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
    }
}
