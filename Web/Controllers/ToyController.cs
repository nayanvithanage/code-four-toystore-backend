using Microsoft.AspNetCore.Mvc;
using toystore_backend.Core.Entities;
using toystore_backend.Core.Services;

namespace toystore_backend.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToyController : ControllerBase
    {
        private readonly ToyService _toyService;

        public ToyController(ToyService toyService)
        {
            _toyService = toyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Toy>> GetAllToysAsync()
        {
            return await _toyService.GetAllToysAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToyById(int id)
        {
            var toy = await _toyService.GetToyByIdAsync(id);
            if (toy == null) return NotFound();
            return toy;
        }

        [HttpPost]
        public async Task<ActionResult> AddToy(Toy toy)
        {
            await _toyService.AddToyAsync(toy);
            return CreatedAtAction(nameof(GetToyById), new { id = toy.Id }, toy);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateToy(Toy toy, int id)
        {
            if (id != toy.Id) return BadRequest();
            await _toyService.UpdateToyAsync(toy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToy(int id)
        {
            await _toyService.DeleteToyAsync(id);
            return NoContent();
        }

        

    }
}