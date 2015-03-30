using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Aws.Worker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable RPC-based API calls.
            config.Routes.MapHttpRoute(
                "RPC-Api",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional },
                new { action = @"^\a\w*$" }); // Constrain this so that in most cases an ID will not be caught by this route. (requires first character to be alphabetic and the rest to be alphanumeric or an underscore)

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}