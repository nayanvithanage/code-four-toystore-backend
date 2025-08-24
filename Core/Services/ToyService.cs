using toystore_backend.Core.Entities;
using toystore_backend.Core.Interfaces;

namespace toystore_backend.Core.Services
{
    public class ToyService
    {
        private readonly IToyRepository _toyRepository;

        //Constructor for service method
        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }
        /*
        This code defines a constructor for the `ToyService` class that takes an `IToyRepository` as a parameter and assigns it to a private field `_toyRepository`. This allows the service to use the repository for data access, following the dependency injection pattern. It makes the service easier to test and maintain by decoupling it from the concrete implementation of the repository.
        */

        //Other service methods
        public async Task<IEnumerable<Toy>> GetAllToysAsync()
        {
            return await _toyRepository.GetAllToysAsync();
        }

        public async Task<Toy?> GetToyByIdAsync(int id)
        {
            return await _toyRepository.GetToyByIdAsync(id);
        }

        public async Task AddToyAsync(Toy toy)
        {
            await _toyRepository.AddToyAsync(toy);
        }

        public async Task UpdateToyAsync(Toy toy)
        {
            await _toyRepository.UpdateToyAsync(toy);
        }

        public async Task DeleteToyAsync(int id)
        {
            await _toyRepository.DeleteToyAsync(id);
        }
    }
}