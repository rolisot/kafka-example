using System;

namespace Kafka.Domain.Contracts
{
    public class OrderItemContract
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }
    }
}