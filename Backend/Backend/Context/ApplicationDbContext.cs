using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }

    }
}
