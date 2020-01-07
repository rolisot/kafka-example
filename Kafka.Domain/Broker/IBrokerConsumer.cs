using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Domain.Broker
{
    public interface IBrokerConsumer
    {
        Task<BrokerResult> ReceiveMessage(string topicName, CancellationToken cancellationToken);
    }
}