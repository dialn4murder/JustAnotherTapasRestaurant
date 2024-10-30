using Microsoft.EntityFrameworkCore;

namespace JustAnotherTapasRestaurant.Model
{
    public class ResturantContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ResturantContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
