using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Party.WebApi.Controllers
{
    [ApiController]
    [Route("api/parties")]
    public class PartiesController : ControllerBase
    {
        private readonly PartyService _partyService;
        private readonly InvitationService _invitationService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Party party)
        {
            var createdParty = await _partyService.CreatePartyAsync(party);
            return CreatedAtAction(nameof(Get), new { id = createdParty.Id }, createdParty);
        }

        [HttpPost("{partyId}/guests/{guestId}")]
        public async Task<IActionResult> AddGuest(int partyId, int guestId)
        {
            await _invitationService.AddGuestToPartyAsync(partyId, guestId);
            return Ok();
        }

        [HttpPut("invitations/{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            [FromQuery] InvitationStatus status)
        {
            await _invitationService.UpdateInvitationStatusAsync(id, status);
            return Ok();
        }

        [HttpDelete("invitations/{id}")]
        public async Task<IActionResult> RemoveGuest(int id)
        {
            await _invitationService.RemoveGuestFromPartyAsync(id);
            return NoContent();
        }
    }
}
