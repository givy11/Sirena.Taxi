using Microsoft.AspNetCore.Mvc;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Prices.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sirena.Taxi.Prices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IRepository<PriceRequest> _priceRepository;

        public PriceController(IRepository<PriceRequest> priceRepository)
        {
            _priceRepository = priceRepository;
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
            await _priceRepository.AddAsync(entity);
            return entity.Id;
        }
    }
}
