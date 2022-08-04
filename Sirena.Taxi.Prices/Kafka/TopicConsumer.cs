using Confluent.Kafka;
using Newtonsoft.Json;
using Sirena.Taxi.Prices.Domain.Entities;
using Sirena.Taxi.Prices.Service;

namespace Sirena.Taxi.Prices.Kafka
{
    public class TopicConsumer : BackgroundService
    {
        private readonly IConfiguration _options;
        private readonly PriceService _priceService;
        public TopicConsumer(IConfiguration options, IServiceProvider serviceProvider)
        {
           _options = options;
           _priceService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<PriceService>();

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
                            var entity = JsonConvert.DeserializeObject<PriceRequest>(cr.Message.Value);
                            await _priceService.UpdatePriceRequestAsync(entity);
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
