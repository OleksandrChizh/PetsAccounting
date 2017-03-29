using System.Collections.Generic;
using System.Threading.Tasks;

using PetsAccounting.BLL.Dto;
using PetsAccounting.BLL.Utils;

namespace PetsAccounting.BLL.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetFilteredAsync(FilterInfo filterInfo = null);

        Task<int> CreateAsync(string name);

        Task DeleteAsync(int id);

        Task<int> GetCountAsync();
    }
}