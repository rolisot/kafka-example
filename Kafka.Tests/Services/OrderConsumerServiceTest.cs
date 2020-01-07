using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Application.Services;
using Kafka.Infra.Consumer;
using Moq;
using Xunit;

namespace Kafka.Tests.Services
{
    public class OrderConsumerServiceTest
    {
        public OrderConsumerServiceTest()
        {
        }

        [Fact]
        public async Task ReceiveOrderSucessTest()
        {
            var cts = new CancellationTokenSource();
            var consumer = GenerateConsumer();
            var orderConsumerService = new OrderConsumerService(consumer);
            var message = await orderConsumerService.ReceiveOrder(cts.Token);
            Assert.True(message.Success);
        }

        private static KafkaConsumer GenerateConsumer()
        {
            var consumer = new Mock<IConsumer<Ignore, string>>();
            consumer.Setup(x => x.Consume(It.IsAny<CancellationToken>()))
                    .Returns(new ConsumeResult<Ignore, string>()
                        { Message = new Message<Ignore, string>() 
                            {Value = "test message"} 
                        });

            return new KafkaConsumer(consumer.Object);
        }
    }
}