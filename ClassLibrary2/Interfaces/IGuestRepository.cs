using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> GetByIdAsync(int id);
        Task<IEnumerable<Guest>> SearchAsync(string query);
        Task AddAsync(Guest guest);
        Task UpdateAsync(Guest guest);
        Task DeleteAsync(int id);
    }
}
