using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MediaTypeFormatter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // this code will make the application return only Json
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            // this code will make the application return only XML
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            // this code will make the application return only Json
            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //   .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
