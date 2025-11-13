using Microsoft.AspNetCore.Mvc;

namespace Party.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : ControllerBase
    {
        private readonly InvitationService _invitationService;

        public InvitationsController(InvitationService invitationService) =>
            _invitationService = invitationService;


        [HttpPost]
        public async Task<IActionResult> SendInvitation([FromBody] InvitationDto dto)
        {
            var invitation = await _invitationService.SendInvitationAsync(dto);
            return CreatedAtAction(nameof(GetInvitation), new { id = invitation.Id }, invitation);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var success = await _invitationService.UpdateStatusAsync(id, status);
            return success ? NoContent() : NotFound();
        }
    }
}
