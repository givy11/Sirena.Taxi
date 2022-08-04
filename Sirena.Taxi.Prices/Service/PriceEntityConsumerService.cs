using Newtonsoft.Json;
using Sirena.Taxi.Core.Abstractions;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Prices.Domain.Entities;

namespace Sirena.Taxi.Prices.Service
{
    public class PriceEntityConsumerService: IEntityConsumerService
    {
        private readonly IRepository<PriceRequest> _priceRepository;

        public PriceEntityConsumerService(IRepository<PriceRequest> priceRepository)
        {
            _priceRepository = priceRepository;
        }


        public async Task UpdatePriceRequestAsync(PriceRequest? pr)
        {
            if (pr == null) return;
            var priceRequest = await _priceRepository.GetByIdAsync(pr.Id);

            if (priceRequest == null)
                return;

            priceRequest.ResponseReceived = true;
            priceRequest.Price = pr.Price;

            await _priceRepository.UpdateAsync(priceRequest);
        }

        public async Task Execute(string topic, string message)
        {
            var entity = JsonConvert.DeserializeObject<PriceRequest>(message);
            await UpdatePriceRequestAsync(entity);
        }
    }
}
