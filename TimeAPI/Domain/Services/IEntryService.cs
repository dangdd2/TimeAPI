using System.Collections.Generic;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Services
{
    public interface IEntryService
    {
        Task<IEnumerable<Entry>> ListAsync();
    }
}
