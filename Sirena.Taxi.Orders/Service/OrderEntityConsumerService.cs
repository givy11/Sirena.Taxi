using Newtonsoft.Json;
using Sirena.Taxi.Core.Abstractions;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Orders.Domain.Entities;

namespace Sirena.Taxi.Orders.Service
{
    public class OrderEntityConsumerService: IEntityConsumerService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderEntityConsumerService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Обновляет заказ данными из сервиса оформления
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task UpdateOrderAsync(Order? order)
        {
            if (order == null) return;
            var entity = await _orderRepository.GetByIdAsync(order.Id);

            if (entity == null)
                return;

            entity.ResponseReceived = true;
            entity.Price = order.Price;
            entity.StateCode = 1;

            await _orderRepository.UpdateAsync(entity);
        }

        /// <inheritdoc />
        public async Task Execute(string topic, string message)
        {
            var entity = JsonConvert.DeserializeObject<Order>(message);
            await UpdateOrderAsync(entity);
        }
    }
}
