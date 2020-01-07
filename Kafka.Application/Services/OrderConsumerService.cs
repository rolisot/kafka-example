using System.Threading;
using System.Threading.Tasks;
using Kafka.Domain.Broker;
using Kafka.Domain.Services;

namespace Kafka.Application.Services
{
    public class OrderConsumerService : IOrderConsumerService
    {
        private readonly IBrokerConsumer Consumer;

        private const string TOPIC_NAME = "fila_pedido";

        public OrderConsumerService(IBrokerConsumer consumer)
        {
            Consumer = consumer;
        }

        public async Task<BrokerResult> ReceiveOrder(CancellationToken cancellationToken)
        {
            return await Consumer.ReceiveMessage(TOPIC_NAME, cancellationToken);
        }
    }
}