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
        public async Task<User?> Get(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<User> Post(User entity)
        {
            entity.Id = Guid.NewGuid();
            await _userRepository.AddAsync(entity);
            return entity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] User entity)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest("Пользователь с указанным Id не существует");
            }

            await _userRepository.UpdateAsync(entity);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest("Пользователь с указанным Id не существует");
            }

            await _userRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
