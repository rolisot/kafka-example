using System;
using System.Text.Json.Serialization;
using Kafka.Domain.Core;

namespace Kafka.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem()
        {
            
        }

        public OrderItem(Guid productId, int quantity, Decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
        
        public Guid ProductId { get; private set; }

        [JsonIgnoreAttribute]
        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public Decimal Price { get; private set; }
    }
}