using System.Collections.Generic;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Services
{
    public interface IDescriptorEntryService
    {
        Task<IEnumerable<DescriptorEntry>> ListAsync();
    }
}
