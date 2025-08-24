using Microsoft.EntityFrameworkCore;
using toystore_backend.Core.Entities;
using toystore_backend.Core.Interfaces;

namespace toystore_backend.Infrastructure.Data
{
    public class ToyRepository : IToyRepository
    {
        private readonly ToyDbContext _toyDbContext;

        public ToyRepository(ToyDbContext dbContext)
        {
            _toyDbContext = dbContext;
        }

        public async Task<IEnumerable<Toy>> GetAllToysAsync()
        {
            return await _toyDbContext.Toys.ToListAsync();
        }

        public async Task<Toy?> GetToyByIdAsync(int id)
        {
            return await _toyDbContext.Toys.FindAsync(id);
        }
        public async Task AddToyAsync(Toy toy)
        {
            await _toyDbContext.Toys.AddAsync(toy);
            await _toyDbContext.SaveChangesAsync();
        }
        public async Task UpdateToyAsync(Toy toy)
        {
            _toyDbContext.Toys.Update(toy);
            await _toyDbContext.SaveChangesAsync();
        }
        public async Task DeleteToyAsync(int id)
        {
            var toy = await _toyDbContext.Toys.FindAsync(id);
            if (toy != null)
            {
                _toyDbContext.Toys.Remove(toy);
                await _toyDbContext.SaveChangesAsync();
            }
        }
        
    }
}