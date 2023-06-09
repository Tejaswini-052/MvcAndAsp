using DemoWebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebapi.Data
{
    public class PassengerDbContext:DbContext
    {
        public PassengerDbContext(DbContextOptions<PassengerDbContext> options) : base(options)
        {

        }
        public DbSet<Passenger> Passengers{ get; set; }
    }
}
