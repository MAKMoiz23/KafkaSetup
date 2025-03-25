namespace KafkaOrderSystem.Producer.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    }
}
