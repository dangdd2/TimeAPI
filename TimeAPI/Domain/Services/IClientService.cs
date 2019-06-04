using System.Collections.Generic;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
    }
}
