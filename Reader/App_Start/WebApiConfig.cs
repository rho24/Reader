using System.Web.Http;

namespace Reader
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) {
            config.Routes.MapHttpRoute(
                name: "UserActions",
                routeTemplate: "api/UserActions/{action}/{id}",
                defaults: new {controller = "UserActions", id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}