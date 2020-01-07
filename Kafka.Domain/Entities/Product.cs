using System;
using Kafka.Domain.Core;

namespace Kafka.Domain.Entities
{
    public class Product : Entity
    {
         protected Product()
        {
            
        }

        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            CreateDate = DateTime.Now;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Decimal Price { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }
    }
}