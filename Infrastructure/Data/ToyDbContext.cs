using toystore_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace toystore_backend.Infrastructure.Data
{
    public class ToyDbContext : DbContext
    {
        public ToyDbContext(DbContextOptions<ToyDbContext> options) : base(options) { }
        public DbSet<Toy> Toys { get; set; }

    }
}