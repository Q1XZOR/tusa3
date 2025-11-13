using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGuestRepository Guests { get; }
        IPartyRepository Parties { get; }
        IInvitationRepository Invitations { get; }
        Task CommitAsync();
    }
}
