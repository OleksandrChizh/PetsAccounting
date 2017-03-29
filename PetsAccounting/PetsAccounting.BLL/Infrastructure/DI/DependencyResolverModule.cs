using Ninject;
using Ninject.Web.Common;
using PetsAccounting.BLL.Interfaces;
using PetsAccounting.BLL.Services;
using PetsAccounting.DAL.Implementations;
using PetsAccounting.DAL.Interfaces;
using PetsAccounting.DAL.Models;

namespace PetsAccounting.BLL.Infrastructure.DI
{
    public static class DependencyResolverModule
    {
        public static void RegisterDependencies(IKernel kernel)
        {
            kernel
                .Bind<ApplicationContext>()
                .ToSelf()
                .InRequestScope()
                .WithConstructorArgument("connectionStringName", "PetsAccountingContext");

            kernel.Bind<IRepository<Owner, int>>().To<OwnerRepository>();
            kernel.Bind<IRepository<Pet, int>>().To<Repository<Pet, int>>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IPetService>().To<PetService>();
        }
    }
}