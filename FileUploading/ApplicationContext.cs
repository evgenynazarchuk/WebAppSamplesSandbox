using Microsoft.EntityFrameworkCore;

namespace FileUploading
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DiskFileModel> DiskFileModel { get; set; }
        public DbSet<DbFileModel> DbFileModel { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
