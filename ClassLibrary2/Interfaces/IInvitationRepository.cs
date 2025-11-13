using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInvitationRepository
    {
        Task<Invitation> GetByIdAsync(int id);
        Task<IEnumerable<Invitation>> GetByPartyIdAsync(int partyId);
        Task<IEnumerable<Invitation>> GetByGuestIdAsync(int guestId);
        Task AddAsync(Invitation invitation);
        Task UpdateAsync(Invitation invitation);
        Task DeleteAsync(int id);
    }
}
