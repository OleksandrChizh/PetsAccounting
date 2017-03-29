using System.Collections.Generic;
using System.Threading.Tasks;

using PetsAccounting.BLL.Dto;
using PetsAccounting.BLL.Utils;

namespace PetsAccounting.BLL.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetFilteredAsync(int ownerId, FilterInfo filterInfo = null);

        Task<int> CreateAsync(int ownerId, string name);

        Task DeleteAsync(int id);

        Task<int> GetCountAsync(int ownerId);
    }
}