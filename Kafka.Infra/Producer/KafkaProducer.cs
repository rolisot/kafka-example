using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Domain.Broker;

namespace Kafka.Infra.Producer
{
    public class KafkaProducer : IBrokerProducer
    {
        private readonly ProducerConfig Config;

        private readonly IProducer<Null, string> Producer;

        public KafkaProducer(string brokerServer)
        { 
            Config = new ProducerConfig { BootstrapServers = brokerServer };
            Producer = new ProducerBuilder<Null, string>(Config).Build();
        }

        public async Task<BrokerResult> SendMessage(BrokerMessage brokerMessage)
        {
            try
            {
                var result = await Producer.ProduceAsync(
                    brokerMessage.TopicName, 
                    new Message<Null, string> { Value = brokerMessage.Message }
                );

                return new BrokerResult(true, $"Mensagem '{result.Value}' de '{result.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }

            return new BrokerResult(false, string.Empty);
        }

        public void Dispose()
        {
            Producer.Dispose();
        }
    }
}