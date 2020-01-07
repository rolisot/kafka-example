namespace Kafka.Domain.Broker
{
    public class BrokerResult
    {
        public BrokerResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }
    }
}