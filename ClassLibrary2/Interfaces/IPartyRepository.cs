using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPartyRepository
    {
        Task<Party> GetByIdAsync(int id);
        Task<IEnumerable<Party>> GetAllAsync();
        Task AddAsync(Party party);
        Task UpdateAsync(Party party);
        Task DeleteAsync(int id);
    }
}
