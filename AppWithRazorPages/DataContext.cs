using Microsoft.EntityFrameworkCore;

namespace AppWithRazorPages
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
