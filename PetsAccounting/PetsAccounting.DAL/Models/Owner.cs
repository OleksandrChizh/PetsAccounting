using System.Collections.Generic;

namespace PetsAccounting.DAL.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}