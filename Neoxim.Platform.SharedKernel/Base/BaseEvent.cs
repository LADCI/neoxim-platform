namespace Neoxim.Platform.SharedKernel
{
    public abstract class BaseEvent
    {
        protected BaseEvent(string eventType, string eventSource, object payload)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTimeOffset.UtcNow;
            EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
            EventSource = eventSource ?? throw new ArgumentNullException(nameof(eventSource));
            EventPayload = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        public Guid Id { get; protected set; }
        public DateTimeOffset CreationDate { get; protected set; }

        public string EventType { get; protected set; }
        public string EventSource { get; protected set; }
        public object EventPayload { get; protected set; }
    }
}