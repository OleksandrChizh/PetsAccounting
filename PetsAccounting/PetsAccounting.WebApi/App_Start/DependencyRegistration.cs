using Ninject;
using PetsAccounting.BLL.Infrastructure.DI;

namespace PetsAccounting.WebApi
{
    public static class DependencyRegistration
    {
        public static void RegisterDependencies(IKernel kernel)
        {
            DependencyResolverModule.RegisterDependencies(kernel);
        }
    }
}