using System;

public class PartyService
{
    private readonly IUnitOfWork _unitOfWork;

    public PartyService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Party> CreatePartyAsync(Party party)
    {
        await _unitOfWork.Parties.AddAsync(party);
        await _unitOfWork.CommitAsync();
        return party;
    }
}

