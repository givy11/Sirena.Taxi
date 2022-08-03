using Microsoft.EntityFrameworkCore;
using Sirena.Taxi.Prices.Domain.Entities;

namespace Sirena.Taxi.Prices.Domain
{
    public class DataContext: DbContext
    {
        public DbSet<PriceRequest> PriceRequests { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DataContext()
        {

        }
    }
}
