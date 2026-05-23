namespace UrbanX.Shared;

/// <summary>
/// Represents a message in the transactional outbox table.
/// Each service persists outbox messages in the same database transaction as domain changes,
/// and a background relay publishes them to Kafka asynchronously.
/// </summary>
public class OutboxMessage
{
    public Guid Id { get; set; }
    public required string EventType { get; set; }
    public required string Payload { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public int RetryCount { get; set; }
}
