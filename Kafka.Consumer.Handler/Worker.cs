using System;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kafka.Consumer.Handler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> Logger;

        public IServiceProvider Services { get; }

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            Logger = logger;
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");
            try
            {
                using (var scope = Services.CreateScope())
                {
                    var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IOrderConsumerService>();

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var message = await scopedProcessingService.ReceiveOrder(stoppingToken);
                        Logger.LogInformation(message.Message);
                    } 
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }
    }
}
