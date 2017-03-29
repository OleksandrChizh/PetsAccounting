using System;
using System.Threading.Tasks;

using PetsAccounting.DAL.Models;

namespace PetsAccounting.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Owner, int> Owners { get; }

        IRepository<Pet, int> Pets { get; }

        Task SaveAsync();
    }
}