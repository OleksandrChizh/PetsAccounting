using System;
using System.Threading.Tasks;

using PetsAccounting.DAL.Interfaces;
using PetsAccounting.DAL.Models;

namespace PetsAccounting.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private readonly Lazy<IRepository<Owner, int>> _owners;
        private readonly Lazy<IRepository<Pet, int>> _pets;

        private bool _disposed;

        public UnitOfWork(
            ApplicationContext applicationContext,
            IRepository<Owner, int> owners,
            IRepository<Pet, int> pets)
        {
            _applicationContext = applicationContext;

            _owners = new Lazy<IRepository<Owner, int>>(() => owners);
            _pets = new Lazy<IRepository<Pet, int>>(() => pets);
        }

        public IRepository<Owner, int> Owners => _owners.Value;

        public IRepository<Pet, int> Pets => _pets.Value;

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _applicationContext.Dispose();
            }

            _disposed = true;
        }
    }
}