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
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PetDto>> GetFilteredAsync(int ownerId, FilterInfo filterInfo = null)
        {
            var petsQuery = await _unitOfWork.Pets.FindAsync(p => p.OwnerId == ownerId);

            if (filterInfo != null)
            {
                petsQuery = petsQuery
                    .OrderBy(o => o.Name)
                    .Skip((filterInfo.PageNumber - 1) * filterInfo.PageSize)
                    .Take(filterInfo.PageSize);
            }

            var pets = petsQuery.ToList();
            var petsDto = pets.Select(p => p.ToDto());

            return petsDto;
        }

        public async Task<int> CreateAsync(int ownerId, string name)
        {
            try
            {
                await _unitOfWork.Owners.GetAsync(ownerId);
            }
            catch (EntityNotFoundException e)
            {
                var message = $"Entity: {e.EntityType.FullName}. Message: {e.Message}";
                throw new ServiceNotFoundException(message);
            }

            var pet = new Pet
            {
                Name = name,
                OwnerId = ownerId
            };

            await _unitOfWork.Pets.CreateAsync(pet);
            await _unitOfWork.SaveAsync();

            return pet.Id;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Pets.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (EntityNotFoundException e)
            {
                var message = $"Entity: {e.EntityType.FullName}. Message: {e.Message}";
                throw new ServiceNotFoundException(message);
            }
        }

        public async Task<int> GetCountAsync(int ownerId)
        {
            var count = await _unitOfWork.Pets.GetCountAsync(p => p.OwnerId == ownerId);

            return count;
        }
    }
}