using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Domain.Broker;

namespace Kafka.Infra.Consumer
{
    public class KafkaConsumer : IBrokerConsumer
    {
        private readonly ConsumerConfig Config;

        private IConsumer<Ignore, string> Consumer;

        protected KafkaConsumer()
        {
            
        }

        public KafkaConsumer(string brokerServer)
        { 
            Config = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = brokerServer,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public KafkaConsumer(IConsumer<Ignore, string> consumer)
        {
            Consumer = consumer;
        }

        public IConsumer<Ignore, string> GenerateConsumer()
        {
            if(Consumer != null)
                return Consumer;
                
            return new ConsumerBuilder<Ignore, string>(Config).Build();
        }

        public async Task<BrokerResult> ReceiveMessage(string topicName, CancellationToken cancellationToken)
        {
            BrokerResult message = null;
            
            using (var consumer = GenerateConsumer())
            {
                try
                {
                    consumer.Subscribe(topicName);

                    if(!cancellationToken.IsCancellationRequested)
                    {
                        var result = consumer.Consume(cancellationToken);
                        consumer.Commit(result);
                        message = new BrokerResult(true, result.Message.Value);
                    } 
                }
                catch (System.Exception ex)
                {
                    message = new BrokerResult(false, ex.Message);
                }
            }

            return message;
        }
    }
}