using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Raven.Client;
using Raven.Client.Document;

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

            builder.Register(c => new DocumentStore {ConnectionStringName = "Server"}.Initialize()).As<IDocumentStore>().SingleInstance();

            builder.Register(c => c.Resolve<IDocumentStore>().OpenSession()).As<IDocumentSession>().InstancePerHttpRequest();

            var container = builder.Build();

            container.ActivateGlimpse();

            Glimpse.RavenDb.Profiler.AttachTo(container.Resolve<IDocumentStore>() as DocumentStore);

            // Set the WebApi dependency resolver.
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Set the MVC dependency resolver.
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}