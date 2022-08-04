using Microsoft.EntityFrameworkCore;
using Sirena.Taxi.Orders.Domain.Entities;

namespace Sirena.Taxi.Orders.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<Order> OrderRequests { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DataContext()
        {

        }
    }
}
