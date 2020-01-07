using Kafka.Domain.Core;

namespace Kafka.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {
        }
        
        public Customer(string name, string document, string zipcode)
        {
            Name = name;
            Document = document;
            Zipcode = zipcode;
        }

        public string Name { get; private set; }

        public string Document { get; private set; }

        public string Zipcode { get; private set; }
    }
}