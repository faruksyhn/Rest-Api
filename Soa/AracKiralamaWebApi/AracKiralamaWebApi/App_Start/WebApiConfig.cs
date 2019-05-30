using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AracKiralamaWebApi
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
       
           
           
            config.Routes.MapHttpRoute(
               name: "Default1Api",
               routeTemplate: "api/{controller}/{sirketId}/{durum}",
               defaults: new { id = RouteParameter.Optional }
           );
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{rezerv}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
