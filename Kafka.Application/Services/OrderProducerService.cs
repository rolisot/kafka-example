using System.Text.Json;
using System.Threading.Tasks;
using Kafka.Domain.Broker;
using Kafka.Domain.Entities;
using Kafka.Domain.Services;
using Kafka.Infra.Producer;

namespace Kafka.Application.Services
{
    public class OrderProducerService : IOrderProducerService
    {
        private readonly IBrokerProducer Producer;

        private const string TOPIC_NAME = "fila_pedido";

        public OrderProducerService(IBrokerProducer producer)
        {
            Producer = producer;
        }

        public async Task<BrokerResult> AddOrder(Order order)
        {
            if(order.Items?.Count == 0)
                return new BrokerResult(false, "This order has no items");

            if(order.CustomerId == null || order.CustomerId == System.Guid.Empty)
                return new BrokerResult(false, "This order has no customer");

            var json = JsonSerializer.Serialize(order);
            var message = new KafkaProducerMessage(json, TOPIC_NAME);

            return await Producer.SendMessage(message);
        }
    }
}