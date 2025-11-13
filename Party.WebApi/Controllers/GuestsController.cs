using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Party.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly GuestService _guestService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guest guest)
        {
            var createdGuest = await _guestService.CreateGuestAsync(guest);
            return CreatedAtAction(nameof(GetType), new { id = createdGuest.Id }, createdGuest);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            var guests = await _guestService.SearchGuestsAsync(q);
            return Ok(guests);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}
