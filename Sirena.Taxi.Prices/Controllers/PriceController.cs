using Microsoft.AspNetCore.Mvc;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Prices.Domain.Entities;
using Sirena.Taxi.Prices.Kafka;

namespace Sirena.Taxi.Prices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IRepository<PriceRequest> _priceRepository;
        private readonly MessageProducer _messageProducer;

        public PriceController(IRepository<PriceRequest> priceRepository, MessageProducer messageProducer)
        {
            _priceRepository = priceRepository;
            _messageProducer = messageProducer;
        }

        [HttpGet]
        public async Task<PriceRequest?> Get(Guid id)
        {
            var user = await _priceRepository.GetByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<Guid> Post(PriceRequest entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Price = null;
            entity.ResponseReceived = false;
            entity.CreatedOn = DateTime.Now.ToUniversalTime();
            await _priceRepository.AddAsync(entity);
            try
            {
                _messageProducer.Produce(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return entity.Id;
        }
    }
}
