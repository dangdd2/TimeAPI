using System.Collections.Generic;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Services
{
    public interface IMatterService
    {
        Task<IEnumerable<Matter>> ListAsync();
    }
}
