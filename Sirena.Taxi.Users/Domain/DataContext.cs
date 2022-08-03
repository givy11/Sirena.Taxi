using Microsoft.EntityFrameworkCore;
using Sirena.Taxi.Users.Domain.Entities;

namespace Sirena.Taxi.Users.Domain
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
