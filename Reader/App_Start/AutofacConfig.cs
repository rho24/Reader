using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Reader.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration configuration) {
            SetAutofacWebApi(configuration);
        }

        private static void SetAutofacWebApi(HttpConfiguration configuration) {
            var builder = new ContainerBuilder();

            // Register MVC controllers using assembly scanning.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf();

            var container = builder.Build();

            container.ActivateGlimpse();

            // Set the WebApi dependency resolver.
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Set the MVC dependency resolver.
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}