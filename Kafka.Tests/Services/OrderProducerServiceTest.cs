using System.Threading.Tasks;
using Kafka.Application.Services;
using Kafka.Domain.Broker;
using Kafka.Domain.Entities;
using Kafka.Domain.Services;
using Moq;
using Xunit;

namespace Kafka.Tests.Services
{
    public class OrderProducerServiceTest
    {
        public OrderProducerServiceTest()
        {
           
        }

        [Fact]
        public async Task AddOrderSucessTest()
        {
            var orderProducerService = GenerateOrderProducerService();
            var result = await orderProducerService.AddOrder(GenerateSucessOrder());

            Assert.True(result.Success);
        }

        [Fact]
        public async Task AddOrderWithNoCustomerTest()
        {
            var orderProducerService = GenerateOrderProducerService();
            var result = await orderProducerService.AddOrder(GenerateOrderWithNoCustomer());

            Assert.False(result.Success);
        }

         [Fact]
        public async Task AddOrderWithNoItemsTest()
        {
            var orderProducerService = GenerateOrderProducerService();
            var result = await orderProducerService.AddOrder(GenerateOrderWithNoItems());

            Assert.False(result.Success);
        }

        private static IOrderProducerService GenerateOrderProducerService()
        {
            var producer = GenerateProducer();
            return new OrderProducerService(producer.Object); 
        }

        private static Mock<IBrokerProducer> GenerateProducer()
        {
            var producer = new Mock<IBrokerProducer>();
            producer.Setup(p => p.SendMessage(It.IsAny<BrokerMessage>()))
                                .ReturnsAsync(new BrokerResult(true, ""));

            return producer; 
        }

        private static Order GenerateSucessOrder()
        {
            var customer = new Customer("Batman", "123456789", "30000");
            var order = new Order(customer);
            var product = new Product("Bat Mask", "Black bat mask", 39.99M);
            var orderItem = new OrderItem(product.Id, 1, 30);

            order.AddItem(orderItem);

            return order;
        }

        private static Order GenerateOrderWithNoCustomer()
        {
            var customer = new Customer("Batman", "123456789", "30000");
            var order = new Order(null);
            var product = new Product("Bat Mask", "Black bat mask", 39.99M);
            var orderItem = new OrderItem(product.Id, 1, 30);

            order.AddItem(orderItem);

            return order;
        }

        private static Order GenerateOrderWithNoItems()
        {
            var customer = new Customer("Batman", "123456789", "30000");
            var order = new Order(customer);
            return order;
        }
    }
}