using Kafka.Application.Services;
using Kafka.Domain.Broker;
using Kafka.Domain.Services;
using Kafka.Infra.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kafka.Consumer.Handler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddScoped<IOrderConsumerService, OrderConsumerService>();
                    services.AddScoped<IBrokerConsumer>( x => {
                        //var brokerServer = Configuration.GetValue<string>("Settings:KafkaServer");
                        var brokerServer = "localhost:9092";
                        return new KafkaConsumer(brokerServer);
                    });
                });
    }
}
