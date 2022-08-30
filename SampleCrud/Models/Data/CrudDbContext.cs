using Microsoft.EntityFrameworkCore;
using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext()
        {

        }
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
