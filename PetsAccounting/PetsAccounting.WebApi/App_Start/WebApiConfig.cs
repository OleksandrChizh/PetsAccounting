using System.Web.Http;

using Ninject;
using Ninject.WebApi.DependencyResolver;

using PetsAccounting.WebApi.Filters;

namespace PetsAccounting.WebApi
{
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            DependencyRegistration.RegisterDependencies(kernel);
            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            config.Filters.Add(new ExceptionFilter());

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}