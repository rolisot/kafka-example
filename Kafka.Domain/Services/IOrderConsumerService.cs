using System.Threading;
using System.Threading.Tasks;
using Kafka.Domain.Broker;

namespace Kafka.Domain.Services
{
    public interface IOrderConsumerService
    {
        Task<BrokerResult> ReceiveOrder(CancellationToken cancellationToken);
    }
}