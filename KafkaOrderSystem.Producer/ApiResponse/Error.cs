namespace KafkaOrderSystem.Producer.ApiResponse
{
    public sealed record Error(string Code, string Desc)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
