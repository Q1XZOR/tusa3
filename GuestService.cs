using System;

public class GuestService
{
    private readonly IUnitOfWork _unitOfWork;

    public GuestService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Guest> CreateGuestAsync(Guest guest)
    {
        await _unitOfWork.Guests.AddAsync(guest);
        await _unitOfWork.CommitAsync();
        return guest;
    }

    public async Task<IEnumerable<Guest>> SearchGuestsAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Enumerable.Empty<Guest>();

        return await _unitOfWork.Guests.SearchAsync(query);
    }

    public async Task DeleteGuestAsync(int id)
    {
        await _unitOfWork.Guests.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
