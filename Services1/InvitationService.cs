using Application.Interfaces;
using Domain;
using System;


public class InvitationService
{
    private readonly IUnitOfWork _unitOfWork;

    public InvitationService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task AddGuestToPartyAsync(int partyId, int guestId)
    {
        var invitation = new Invitation
        {
            PartyId = partyId,
            GuestId = guestId,
            Status = InvitationStatus.Invited,
            SentAt = DateTime.UtcNow
        };

        await _unitOfWork.Invitations.AddAsync(invitation);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateInvitationStatusAsync(int invitationId, InvitationStatus status)
    {
        var invitation = await _unitOfWork.Invitations.GetByIdAsync(invitationId);
        if (invitation != null)
        {
            invitation.Status = status;
            invitation.RespondedAt = DateTime.UtcNow;
            await _unitOfWork.Invitations.UpdateAsync(invitation);
            await _unitOfWork.CommitAsync();
        }
    }

    public async Task RemoveGuestFromPartyAsync(int invitationId)
    {
        await _unitOfWork.Invitations.DeleteAsync(invitationId);
        await _unitOfWork.CommitAsync();
    }
}