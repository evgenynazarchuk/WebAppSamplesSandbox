using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
