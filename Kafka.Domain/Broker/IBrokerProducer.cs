using System;
using System.Threading.Tasks;

namespace Kafka.Domain.Broker
{
    public interface IBrokerProducer : IDisposable
    {
        Task<BrokerResult> SendMessage(BrokerMessage message);
    }
}