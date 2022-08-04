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
        private readonly IRepository<Order> _orderRepository;
        private readonly MessageProducer _messageProducer;

        public OrderController(IRepository<Order> orderRepository, MessageProducer messageProducer)
        {
            _orderRepository = orderRepository;
            _messageProducer = messageProducer;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IEnumerable<Order>> GetList()
        {
            var users = await _orderRepository.GetAllAsync();
            return users;
        }

        [HttpGet]
        public async Task<Order?> Get(Guid id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);
            return entity;
        }

        [HttpPost]
        [Route("Place")]
        public async Task<Guid> Post(Order entity)
        {
            entity.Id = Guid.NewGuid();
            entity.ResponseReceived = false;
            entity.CreatedOn = DateTime.Now.ToUniversalTime();
            await _orderRepository.AddAsync(entity);
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

        [HttpPut("{id}")]
        [Route("Cancel")]
        public async Task<IActionResult> Put(Guid id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return BadRequest("Заказ с указанным Id не существует");
            }

            entity.StateCode = 2; 

            await _orderRepository.UpdateAsync(entity);
            return Ok();

        }
    }
}
