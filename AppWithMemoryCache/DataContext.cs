using Microsoft.EntityFrameworkCore;

namespace AppWithMemoryCache
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
