using System.Linq;

using PetsAccounting.BLL.Dto;
using PetsAccounting.DAL.Models;

namespace PetsAccounting.BLL.Infrastructure.Mapper
{
    public static class MapperToDto
    {
        public static OwnerDto ToDto(this Owner owner)
        {
            return new OwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Pets = owner.Pets.Select(p => p.ToDto())
            };
        }

        public static PetDto ToDto(this Pet pet)
        {
            return new PetDto
            {
                Id = pet.Id,
                Name = pet.Name
            };
        }
    }
}