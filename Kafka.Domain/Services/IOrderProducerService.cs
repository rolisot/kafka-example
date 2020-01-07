using System.Threading.Tasks;
using Kafka.Domain.Broker;
using Kafka.Domain.Entities;

namespace Kafka.Domain.Services
{
    public interface IOrderProducerService
    {
        Task<BrokerResult> AddOrder(Order order);
    }
}