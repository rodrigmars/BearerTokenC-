using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace MicroServiceWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();

            //TODO: IMPLENTA TOKEN OAUTH
            //ConfigurationOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            // remove support for xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // force json indentation
            config.Formatters.JsonFormatter.Indent = true;

            // Web API Attribute routing.
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            return config;
        }
    }
}
