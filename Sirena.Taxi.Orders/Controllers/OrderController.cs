using Microsoft.AspNetCore.Mvc;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Core.Kafka;
using Sirena.Taxi.Orders.Domain.Entities;

namespace Sirena.Taxi.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _priceRepository;
        private readonly MessageProducer _messageProducer;

        public OrderController(IRepository<Order> priceRepository, MessageProducer messageProducer)
        {
            _priceRepository = priceRepository;
            _messageProducer = messageProducer;
        }

        [HttpGet]
        public async Task<Order?> Get(Guid id)
        {
            var user = await _priceRepository.GetByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<Guid> Post(Order entity)
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
