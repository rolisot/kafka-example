using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Kafka.Domain.Core;

namespace Kafka.Domain.Entities
{
    public class Order : Entity
    {
        protected Order()
        {
            OrderDate = DateTime.Now;
        }

        public Order(Customer customer)
        {
            OrderDate = DateTime.Now;
            Customer = customer;
            CustomerId = Customer != null ? Customer.Id : Guid.Empty;
            items = new List<OrderItem>();
        }

        private List<OrderItem> items;

        public DateTime OrderDate { get; private set; }

        public Guid CustomerId { get; private set; }

        [JsonIgnoreAttribute]
        public Customer Customer { get; private set; }

        public IReadOnlyCollection<OrderItem> Items { get{return items;} private set{ items =  (List<OrderItem>) value;} }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }
    }
}