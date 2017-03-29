using System.Collections.Generic;

namespace PetsAccounting.BLL.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PetDto> Pets { get; set; }
    }
}