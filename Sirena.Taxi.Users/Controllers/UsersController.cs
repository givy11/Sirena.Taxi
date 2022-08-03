using Microsoft.AspNetCore.Mvc;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Users.Domain.Entities;

namespace Sirena.Taxi.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IEnumerable<User>> GetList()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<User> Post(User entity)
        {
            entity.Id = Guid.NewGuid();
            await _userRepository.AddAsync(entity);
            return entity;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
