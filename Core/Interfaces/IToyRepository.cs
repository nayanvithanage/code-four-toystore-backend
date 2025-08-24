using System.Diagnostics.Eventing.Reader;
using toystore_backend.Core.Entities;

namespace toystore_backend.Core.Interfaces 
{
    public interface IToyRepository
    {
        Task<IEnumerable<Toy>> GetAllToysAsync();
        Task<Toy?> GetToyByIdAsync(int id);
        Task AddToyAsync(Toy toy);
        Task UpdateToyAsync(Toy toy);
        Task DeleteToyAsync(int id);
    }
}