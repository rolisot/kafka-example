using Kafka.Domain.Broker;

namespace Kafka.Infra.Producer
{
    public class KafkaProducerMessage : BrokerMessage
    {
        public KafkaProducerMessage(string message, string topicName)
        {
            Message = message;
            TopicName = topicName;
        }
    }
}