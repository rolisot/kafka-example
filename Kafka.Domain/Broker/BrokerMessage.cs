namespace Kafka.Domain.Broker
{
    public abstract class BrokerMessage
    {
        public string Message { get; protected set; }

        public string TopicName { get; protected set; }
    }
}