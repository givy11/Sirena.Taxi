using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Prices.Domain.Entities;

namespace Sirena.Taxi.Prices.Service
{
    public class PriceService
    {
        private readonly IRepository<PriceRequest> _priceRepository;

        public PriceService(IRepository<PriceRequest> priceRepository)
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

    }
}
