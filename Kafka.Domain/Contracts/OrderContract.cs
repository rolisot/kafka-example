using System;
using System.Collections.Generic;

namespace Kafka.Domain.Contracts
{
    public class OrderContract
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemContract> Items { get; set; }
    }
}