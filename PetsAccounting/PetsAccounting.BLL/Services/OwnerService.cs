using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PetsAccounting.BLL.Dto;
using PetsAccounting.BLL.Exceptions;
using PetsAccounting.BLL.Infrastructure.Mapper;
using PetsAccounting.BLL.Interfaces;
using PetsAccounting.BLL.Utils;
using PetsAccounting.DAL.Exceptions;
using PetsAccounting.DAL.Interfaces;
using PetsAccounting.DAL.Models;

namespace PetsAccounting.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OwnerDto>> GetFilteredAsync(FilterInfo filterInfo = null)
        {
            IQueryable<Owner> ownersQuery = await _unitOfWork.Owners.FindAsync();

            if (filterInfo != null)
            {
                ownersQuery = ownersQuery
                    .OrderBy(o => o.Name)
                    .Skip((filterInfo.PageNumber - 1) * filterInfo.PageSize)
                    .Take(filterInfo.PageSize);
            }

            var owners = ownersQuery.ToList();
            var ownersDto = owners.Select(o => o.ToDto());

            return ownersDto;
        }

        public async Task<int> CreateAsync(string name)
        {
            var owner = new Owner { Name = name };

            await _unitOfWork.Owners.CreateAsync(owner);
            await _unitOfWork.SaveAsync();

            return owner.Id;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Owners.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (EntityNotFoundException e)
            {
                var message = $"Entity: {e.EntityType.FullName}. Message: {e.Message}";
                throw new ServiceNotFoundException(message);
            }
        }

        public async Task<int> GetCountAsync()
        {
            var count = await _unitOfWork.Owners.GetCountAsync();

            return count;
        }
    }
}
