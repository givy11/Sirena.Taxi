using Newtonsoft.Json;
using Sirena.Taxi.Core.Abstractions;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Core.Domain;
using Sirena.Taxi.Core.Kafka;
using Sirena.Taxi.PseudoProviders.Models.Internal;

namespace Sirena.Taxi.PseudoProviders.Service
{
    public class YandexPriceService: IEntityConsumerService, ITaxiClient
    {
        private readonly MessageProducer _messageProducer;

        public YandexPriceService(MessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public async Task Execute(string topic, string message)
        {
            var entity = JsonConvert.DeserializeObject<PriceRequest>(message);
            if (entity != null) RequestData(entity);
        }

        public void RequestData(BaseEntity entity)
        {
            if (entity is PriceRequest priceRequest)
            {
                priceRequest.Price = Random.Shared.Next(0, 3000);
                try
                {
                    _messageProducer.Produce(priceRequest);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
