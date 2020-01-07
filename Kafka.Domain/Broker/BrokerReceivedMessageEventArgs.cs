using System;

namespace Kafka.Domain.Broker
{
    public class BrokerReceivedMessageEventArgs : EventArgs
    {
        public BrokerReceivedMessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}