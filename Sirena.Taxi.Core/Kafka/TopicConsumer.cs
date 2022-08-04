using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sirena.Taxi.Core.Abstractions;

namespace Sirena.Taxi.Core.Kafka
{
    public class TopicConsumer : BackgroundService
    {
        private readonly IConfiguration _options;
        private readonly IEntityConsumerService _entityConsumerService;
        public TopicConsumer(IConfiguration options, IServiceProvider serviceProvider)
        {
           _options = options;
           _entityConsumerService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IEntityConsumerService>();
        }

        protected override async Task<Task> ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var connection = _options.GetSection("Kafka");
            var consumerConfig = new ConsumerConfig(
                new Dictionary<string, string>{
                    {"bootstrap.servers", connection["Host"]},
                    {"security.protocol", "SASL_SSL"},
                    {"ssl.ca.location", connection["CA"]},
                    {"sasl.mechanisms", "SCRAM-SHA-512"},
                    {"sasl.username", connection["User"]},
                    {"sasl.password", connection["Password"]},
                    {"group.id", "demo"},
                    {"auto.offset.reset", "earliest"}
                }
            );
            consumerConfig.AutoOffsetReset = AutoOffsetReset.Earliest;

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe(connection["ConsumerTopic"]);
                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(100);
                        if (cr != null)
                        {
                            _entityConsumerService.Execute(connection["ConsumerTopic"], cr.Message.Value);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    //Обработка Ctrl+C
                }
                finally
                {
                    consumer.Close();
                }
            }

            return Task.CompletedTask;
        }
    }
}
