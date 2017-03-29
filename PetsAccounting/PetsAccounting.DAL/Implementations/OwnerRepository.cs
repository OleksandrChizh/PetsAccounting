using System.Data.Entity;
using System.Threading.Tasks;

using PetsAccounting.DAL.Exceptions;
using PetsAccounting.DAL.Models;

namespace PetsAccounting.DAL.Implementations
{
    public class OwnerRepository : Repository<Owner, int>
    {
        private readonly DbSet<Pet> _petsDbSet;

        public OwnerRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
            _petsDbSet = applicationContext.Set<Pet>();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException("Entity with such id is not found", typeof(Owner));
            }

            await Task.Run(
                () =>
                {
                    _petsDbSet.RemoveRange(entity.Pets);
                    DbSet.Remove(entity);
                });
        }
    }
}
