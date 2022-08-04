using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Core.Kafka
{
    /// <summary>
    /// Продюсер сообщений в Кафка.
    /// </summary>
    public class MessageProducer
    {
        private readonly IConfiguration _options;

        public MessageProducer(IConfiguration options)
        {
            _options = options;
        }

        /// <summary>
        /// Отправить сообщение в топик.
        /// </summary>
        /// <param name="entity">Сообщение для топика.</param>
        /// <exception cref="Exception">Ошибка доставки.</exception>
        public void Produce(BaseEntity entity)
        {
            var connection = _options.GetSection("Kafka");
            var producerConfig = new ProducerConfig(
                new Dictionary<string, string>{
                    {"bootstrap.servers", connection["Host"]},
                    {"security.protocol", "SASL_SSL"},
                    {"ssl.ca.location", connection["CA"]},
                    {"sasl.mechanisms", "SCRAM-SHA-512"},
                    {"sasl.username", connection["User"]},
                    {"sasl.password", connection["Password"]}
                }
            );

            var producer = new ProducerBuilder<string, string>(producerConfig).Build();

            foreach (var topic in connection.GetSection("ProducerTopics").Get<List<string>>())
            {
                producer.Produce(topic, new Message<string, string> { Key = entity.Id.ToString(), Value = JsonConvert.SerializeObject(entity) },
                    (deliveryReport) =>
                    {
                        if (deliveryReport.Error.Code != ErrorCode.NoError)
                        {
                            throw new Exception($"Ошибка доставки сообщения: {deliveryReport.Error.Reason}");
                        }
                    });
            }
            producer.Flush(TimeSpan.FromSeconds(2));
        }
    }
}
